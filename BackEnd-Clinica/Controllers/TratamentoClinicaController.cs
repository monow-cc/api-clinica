using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.HUB;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.TratamentoClinica;
using BackEnd_Clinica.VOS.Exit.TratamentoClinica;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd_Clinica.Exeption;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamentoClinicaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<ClinicaHUB> _hubContext;


        public TratamentoClinicaController(AppDbContext context, IMapper mapper, IHubContext<ClinicaHUB> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }
        [Authorize]
        [HttpPost]

        public async Task<ActionResult<TratamentoClinicaVOExit>> Post (TratamentoClinicaVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token

            var tratamento = _mapper.Map<TratamentoClinicaVOEnter,TratamentoClinica>(entity);

            tratamento.ClinicaId = clinicaId;
            tratamento.Deletado = false;

            await _context.TratamentoClinicas.AddAsync(tratamento);
            await _context.SaveChangesAsync();
            
            var exit = _mapper.Map<TratamentoClinica, TratamentoClinicaVOExit>(tratamento);
            await _hubContext.Clients.GroupExcept(clinicaId.ToString(),entity.ConnectionID).SendAsync("newtratamento", exit);
            return Ok(exit);
        }
        [Authorize]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<TratamentoClinicaVOExit>>> GetAll()
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token

            var tratamento = await _context.TratamentoClinicas.Where(x => x.ClinicaId == clinicaId && x.Deletado == false).ToListAsync();

            var exit = _mapper.Map<List<TratamentoClinica>, List<TratamentoClinicaVOExit>>(tratamento);

            return Ok(exit);
        }
        [Authorize]
        [HttpPut("Delete")]
        public async Task<ActionResult<TratamentoClinicaVOExit>> Delete (TratamentoClinicaDeleteVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token

            var verify = await _context.TratamentoClinicas.Where(e => e.Id == entity.Id).Include(x => x.Agendamentos).FirstOrDefaultAsync();
            if (verify == null) throw new AplicationRequestExeption("Tratamento ja deletado", HttpStatusCode.Unauthorized);
            if(verify.Agendamentos?.Count > 0)
            {
                verify.Deletado = true;
                _context.TratamentoClinicas.Entry(verify).State = EntityState.Modified;   
            }
            else
            {
                _context.TratamentoClinicas.Entry(verify).State = EntityState.Deleted;             
            }
            await _context.SaveChangesAsync();
            var exit = _mapper.Map<TratamentoClinica, TratamentoClinicaVOExit>(verify);
            await _hubContext.Clients.GroupExcept(clinicaId.ToString(), entity.ConnectionId).SendAsync("deletetratamento", exit);

            return Ok(exit);
        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<ActionResult<TratamentoClinicaVOExit>> Update(TratamentoClinicaUpdateVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token

            var convert = _mapper.Map<TratamentoClinicaUpdateVOEnter, TratamentoClinica>(entity);
            convert.ClinicaId = clinicaId;
            _context.TratamentoClinicas.Entry(convert).State = EntityState.Modified;
          
            await _context.SaveChangesAsync();
            var exit = _mapper.Map<TratamentoClinica, TratamentoClinicaVOExit>(convert);
            await _hubContext.Clients.GroupExcept(clinicaId.ToString(), entity.ConnectionID).SendAsync("updatetratamento", exit);

            return Ok(exit);
        }

    }
}
