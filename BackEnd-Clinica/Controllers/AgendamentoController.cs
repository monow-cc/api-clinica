using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.HUB;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Agendamento;
using BackEnd_Clinica.VOS.Enter.Agendamento.Update;
using BackEnd_Clinica.VOS.Exit.Agendamento;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<ClinicaHUB> _hubContext;

        public AgendamentoController(AppDbContext context, IMapper mapper, IHubContext<ClinicaHUB> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Agendamento>> Create(AgendamentoVOEnter entity)
        {

            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token
            var get = await _context.Agendamento.Where(x => x.ClinicaId == clinicaId && x.ProfissionalClinicaId == entity.ProfissionalId && x.Data == entity.Data && x.Horario == entity.Horario).FirstOrDefaultAsync();
            if (get != null) throw new AplicationRequestExeption("Uma consulta já foi criada nesse dia e horario", HttpStatusCode.Unauthorized);
            var convert = _mapper.Map<AgendamentoVOEnter, Agendamento>(entity);
            convert.ClinicaId = clinicaId;
            await _context.Agendamento.AddAsync(convert);
            await _context.SaveChangesAsync();
            var Redirect = await _context.Agendamento.Include(e => e.Paciente).Include(e => e.TratamentoClinica).FirstOrDefaultAsync(e => e.Id == convert.Id);
            var RedirectConvert = _mapper.Map<Agendamento, AgendamentoVOExit>(Redirect);
            var Data = new
            {
                Data = entity.Data
            };
            await _hubContext.Clients.GroupExcept(clinicaId.ToString(), entity.ConnectionId).SendAsync("newconsulta", RedirectConvert, Data);
            return Ok(RedirectConvert);
        }
        [Authorize]
        [HttpPost("GetAll")]
        public async Task<ActionResult<Agendamento>> GetAll(AgendamentoGetAllVOEnter entity)
        {

            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token
            var get = await _context.Agendamento.Where(x => x.ClinicaId == clinicaId && x.ProfissionalClinicaId == entity.ProfissionalId && x.Data == entity.Data).Include(e => e.Paciente).Include(e => e.TratamentoClinica).Include(x => x.ProfissionalClinica).ThenInclude(x => x.Profissional).ToListAsync();
            
            var convert = _mapper.Map<List<Agendamento>, List<AgendamentoVOExit>>(get);
            
           

            return Ok(convert);
        }
        [Authorize]
        [HttpPut("UpdateTime")]
        public async Task<ActionResult<Agendamento>> UpdateTime(AgendamentoUpdateTimeVOEnter entity)
        {

            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token
            var get = await _context.Agendamento.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (get == null) throw new AplicationRequestExeption("Agendamento não encontrado",HttpStatusCode.Unauthorized);
            get.Horario = entity.Horario;
            _context.Agendamento.Entry(get).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var convert = _mapper.Map<Agendamento, AgendamentoVOExit>(get);
            await _hubContext.Clients.GroupExcept(clinicaId.ToString(), entity.ConnectionId).SendAsync("updateconsulta", convert);

            return Ok(convert);
        }
        [Authorize]
        [HttpPut("UpdatePagamento")]
        public async Task<ActionResult<Agendamento>> UpdatePagamento(AgendamentoUpdatePagamentoVOEnter entity)
        {

            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token
            var get = await _context.Agendamento.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (get == null) throw new AplicationRequestExeption("Agendamento não encontrado", HttpStatusCode.Unauthorized);
            get.Pago = true;
            get.Metodo = entity.Metodo;
            _context.Agendamento.Entry(get).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var convert = _mapper.Map<Agendamento, AgendamentoVOExit>(get);
            await _hubContext.Clients.GroupExcept(clinicaId.ToString(), entity.ConnectionId).SendAsync("updateconsultapag", convert);

            return Ok(convert);
        }
    }
}
