using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.HUB;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.Services;
using BackEnd_Clinica.VOS.Enter.Paciente;
using BackEnd_Clinica.VOS.Exit.Paciente;
using BackEnd_Clinica.VOS.Exit.PacienteClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly Gerador _gerador;
        private readonly IHubContext<ClinicaHUB> _hubContext;

        public PacienteController(AppDbContext context, IMapper mapper, Gerador gerador, IHubContext<ClinicaHUB> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _gerador = gerador;
            _hubContext = hubContext;
        }
        [Authorize]
        [HttpPost("clinica")]
        public async Task<ActionResult<PacienteVOExit>> Post(PacienteVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);//Pega id da clinica no token
            if (entity.Cpf == 0) throw new AplicationRequestExeption("O CPF Esta em um formato invalido", HttpStatusCode.Unauthorized);
            var verify = await _context.Pacientes.FirstOrDefaultAsync(e => e.Cpf ==  entity.Cpf); // verifica se a conta esta cadastrada
            if (verify != null) throw new AplicationRequestExeption("CPF já esta cadastrado", HttpStatusCode.Unauthorized); // retorna erro
            var verifyClinica = await _context.PacientesClinica.Include(i => i.Paciente).Where(i => i.ClinicaId == clinicaId && i.Paciente.Cpf == entity.Cpf).FirstOrDefaultAsync(); // verifica se o paciente ja esta na clinica
            if (verifyClinica != null) throw new AplicationRequestExeption("Paciente ja esta cadastrado em sua clinica", HttpStatusCode.Unauthorized);// retorna erro

            var paciente = _mapper.Map<PacienteVOEnter,Paciente>(entity); // converte entrada para model
            paciente.Password = GetRandomPassword(10); // cria uma senha randomica
            paciente.Cadastro = await _gerador.GerarCadastro();

            await _context.Pacientes.AddAsync(paciente); // adicioanr
            await _context.SaveChangesAsync(); // salva


            var gerador = new GeradorPaciente()
            {
                ClinicaId = clinicaId,
                PacienteId = paciente.Id
            };
            await _context.GeradorPacientes.AddAsync(gerador);
            await _context.SaveChangesAsync();

            var newItem = new PacienteClinica()
            {
                ClinicaId = clinicaId,
                PacienteId = paciente.Id,
            };
           
            await _context.PacientesClinica.AddAsync(newItem);
            await _context.SaveChangesAsync();
            var convert = _mapper.Map<PacienteClinica, PacienteClinicaVOExit>(newItem);

            await _hubContext.Clients.Group(clinicaId.ToString()).SendAsync("receivepaciente", convert);

            return Ok(paciente); // retorna para o response
        }

       
      


        public static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}
