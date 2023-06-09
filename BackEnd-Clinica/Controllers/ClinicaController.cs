using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Exit.Clinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClinicaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Clinica>> Post(Clinica entity)
        {   
            entity.CreatedAt = DateTime.UtcNow;
            await _context.Clinicas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ClinicaAuthVOExit>> GetAuth ()
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!); // pega a clinica do token do usuario

            var get = await _context.Clinicas.Include(x => x.ProfissionalClinicas.Where(e => e.Status != 3)).ThenInclude(x => x.Profissional).Include(x => x.PacienteClinicas).ThenInclude(x => x.Paciente).Include(x => x.TratamentoClinicas.Where(e => e.Deletado == false)).FirstOrDefaultAsync(x => x.Id == clinicaId);

            var convert = _mapper.Map<Clinica, ClinicaAuthVOExit>(get);
            return Ok(convert);
        }
    }
}
