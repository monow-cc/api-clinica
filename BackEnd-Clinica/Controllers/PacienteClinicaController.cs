﻿using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.HUB;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.PacienteClinica;
using BackEnd_Clinica.VOS.Exit.PacienteClinica;
using BackEnd_Clinica.VOS.Exit.Profile;
using BackEnd_Clinica.VOS.Exit.ProfissionalClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteClinicaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<ClinicaHUB> _hubContext;

        public PacienteClinicaController(AppDbContext context, IMapper mapper, IHubContext<ClinicaHUB> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PacienteClinicaVOExit>> Post(PacienteClinicaVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);

            var verifyCPF = await _context.Pacientes.Where(e => e.Cpf == entity.Value || e.Cadastro == entity.Value).FirstOrDefaultAsync();
            if (verifyCPF == null) throw new AplicationRequestExeption("Paciente não cadastrado no sistema, Gere uma conta", HttpStatusCode.Unauthorized);
            var verifyClinicaPaciente = await _context.PacientesClinica.Include(p => p.Paciente).Where(e => (e.Paciente.Cpf == entity.Value || e.Paciente.Cadastro == entity.Value) && e.ClinicaId == clinicaId).FirstOrDefaultAsync();
            if (verifyClinicaPaciente != null) throw new AplicationRequestExeption("Paciente Já cadastrado em sua clinica", HttpStatusCode.Unauthorized);

            var newItem = new PacienteClinica()
            {
                ClinicaId = clinicaId,
                PacienteId = verifyCPF.Id,
            };

            await _context.PacientesClinica.AddAsync(newItem);
            await _context.SaveChangesAsync();

            var convert = _mapper.Map<PacienteClinica, PacienteClinicaVOExit>(newItem);
            await _hubContext.Clients.GroupExcept(clinicaId.ToString(),entity.Connection).SendAsync("receivepaciente", convert);
            return Ok(convert);

        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteClinicaVOExit>>> GetAll()
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token
            var get = await _context.PacientesClinica.Where(c => c.ClinicaId.Equals(clinicaId)).Include(p => p.Paciente).ToListAsync(); // pega todos os profissionais na clinica
            var pacienteVO = _mapper.Map<List<PacienteClinica>, List<PacienteClinicaVOExit>>(get);// converte retorno em lista de VOS
            return Ok(pacienteVO);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileClinicaVOExit>> GetProfile(Guid id)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token
            var get = await _context.PacientesClinica.Where(x => x.Id == id && x.ClinicaId == clinicaId)
                .Include(x=> x.Paciente).Include(x=> x.Receitas)
                    .ThenInclude(x => x.ReceitaArquivos)
                .Include(x => x.Historicos)
                     .ThenInclude(e => e.Paciente)
                .Include(x => x.Historicos).
                    ThenInclude(x => x.ProfissionalClinica)
                    .ThenInclude(x => x.Profissional)
                .Include(x => x.Historicos)
                    .ThenInclude(e => e.TratamentoClinica)
                .FirstOrDefaultAsync();
            if(get == null) throw new AplicationRequestExeption("Você não tem permissão para ver esse perfil", HttpStatusCode.Unauthorized);
            var convert = _mapper.Map<PacienteClinica,ProfileClinicaVOExit>(get);
            return Ok(convert);
        }

    }
}
