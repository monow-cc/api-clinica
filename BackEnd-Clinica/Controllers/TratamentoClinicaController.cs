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

            var tratamento = await _context.TratamentoClinicas.Where(x => x.ClinicaId == clinicaId).ToListAsync();

            var exit = _mapper.Map<List<TratamentoClinica>, List<TratamentoClinicaVOExit>>(tratamento);

            return Ok(exit);
        }

    }
}
