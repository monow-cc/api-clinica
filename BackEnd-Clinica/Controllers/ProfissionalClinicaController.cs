using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.HUB;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.ProfissionalClinica;
using BackEnd_Clinica.VOS.Exit.Clinica;
using BackEnd_Clinica.VOS.Exit.ProfissionalClinica;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalClinicaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<ClinicaHUB> _hubContext;

        public ProfissionalClinicaController(AppDbContext context, IMapper mapper, IHubContext<ClinicaHUB> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProfissionalClinicaVOExit>> Post (ProfissionalClinicaVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!); // pega a clinica do token do usuario

            var verifyEmail = await _context.Profissional.FirstOrDefaultAsync(e => e.Email == entity.Email); //verifica se esta cadastrado
            
            if (verifyEmail == null) throw new AplicationRequestExeption("Email não cadastrado", HttpStatusCode.Unauthorized); // retorno de erro

            var verify = await _context.ProfissionalClinicas.Where(e => e.ProfissionalId == verifyEmail.Id && e.ClinicaId == clinicaId).FirstOrDefaultAsync(); // verifica se ja esta na clinica
            
            if (verify != null && verify.Status == 1) throw new AplicationRequestExeption("Profissional já esta convidado", HttpStatusCode.Unauthorized);// retorna erro
            else if (verify != null && verify.Status == 2) throw new AplicationRequestExeption("Profissional já esta ativo em sua clinica", HttpStatusCode.Unauthorized);// retorna erro
            else if (verify != null && verify.Status == 3)
            {
                verify.Status = 1;

                _context.ProfissionalClinicas.Entry(verify).State = EntityState.Modified;
                await _context.SaveChangesAsync(); // salva
                var profissionaisVOChange = _mapper.Map<ProfissionalClinica, ProfissionalClinicaVOExit>(verify); //Converte para retorno

                await _hubContext.Clients.GroupExcept(clinicaId.ToString(), entity.ConnectionID).SendAsync("newprofissional", profissionaisVOChange); // envia em tempo real para os outros clientes

                return Ok(profissionaisVOChange);// retorna o novo profissional da clinica
            }

            var newProf = new ProfissionalClinica() // cria um novo model para envio para o banco de dados
            {
                ClinicaId = clinicaId, //clinica do token
                ProfissionalId = verifyEmail.Id, // id do profissional
                Status = 1, // pendente
            };
            
            await _context.ProfissionalClinicas.AddAsync(newProf); // envia
            await _context.SaveChangesAsync(); // salva

            //TooDoo Repassar para o signalR
            var profissionaisVO = _mapper.Map<ProfissionalClinica, ProfissionalClinicaVOExit>(newProf); //Converte para retorno

           await _hubContext.Clients.GroupExcept(clinicaId.ToString(),entity.ConnectionID).SendAsync("newprofissional", profissionaisVO); // envia em tempo real para os outros clientes

            return Ok(profissionaisVO);// retorna o novo profissional da clinica

        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ClinicaProfVOExit>> ChangeStatus(ProfissionalClinicaUpdateVOEnter entity)
        {
            Guid userId = Guid.Parse(HttpContext.Items["Id"]!.ToString()!);
            var get = await _context.ProfissionalClinicas.Where(e => e.ClinicaId == entity.Id && e.ProfissionalId == userId).Include(p => p.Profissional).Include(x => x.Clinica).FirstOrDefaultAsync();
            if (get == null) throw new AplicationRequestExeption("Convite não encontrado", HttpStatusCode.Unauthorized);
            get.Status = 2;

            _context.ProfissionalClinicas.Entry(get).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var convert = _mapper.Map<ProfissionalClinica, ClinicaProfVOExit>(get);
            var convertToClinica = _mapper.Map<ProfissionalClinica, ProfissionalClinicaVOExit>(get);
            await _hubContext.Clients.Group(get.ClinicaId.ToString()).SendAsync("receiveprofissionalstatus", convertToClinica, get.Profissional.Name);

           

            return Ok(convert);

        }

        [Authorize]
        [HttpPut("Delete")]
        public async Task<ActionResult<ClinicaProfVOExit>> RemoveProfissional(ProfissionalClinicaUpdateVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);
            var get = await _context.ProfissionalClinicas.Where(e => e.ClinicaId == clinicaId && e.Id == entity.Id).Include(p => p.Profissional).Include(x => x.Clinica).FirstOrDefaultAsync();
            if (get == null) throw new AplicationRequestExeption("Convite não encontrado", HttpStatusCode.Unauthorized);
            get.Status = 3;

            _context.ProfissionalClinicas.Entry(get).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var convert = _mapper.Map<ProfissionalClinica, ClinicaProfVOExit>(get);
            
            var convertToClinica = _mapper.Map<ProfissionalClinica, ProfissionalClinicaVOExit>(get);
            await _hubContext.Clients.GroupExcept(get.ClinicaId.ToString(),entity.ConnectionId).SendAsync("deleteprofissional", convertToClinica, get.Profissional.Name);



            return Ok(convertToClinica);

        }

    }
}
