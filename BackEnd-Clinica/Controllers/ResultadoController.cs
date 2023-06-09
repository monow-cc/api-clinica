using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Receita;
using BackEnd_Clinica.VOS.Enter.Resultado;
using BackEnd_Clinica.VOS.Exit.Receita;
using BackEnd_Clinica.VOS.Exit.Reultado;
using BackEnd_Clinica.VOS.Exit.TratamentoClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ResultadoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ResultadoVOExit>> Post(ResultadoVOEnter entity)
        {
            var map = _mapper.Map<ResultadoVOEnter, Resultado>(entity);
            map.Created_At = DateTime.Now;
            await _context.Resultados.AddAsync(map);
            await _context.SaveChangesAsync();
            var convert = _mapper.Map<Resultado, ResultadoVOExit>(map);
            return Ok(convert);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultadoVOExit>> Delete(Guid id)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token

            var verify = await _context.Resultados.Where(e => e.Id == id).FirstOrDefaultAsync();

            _context.Resultados.Entry(verify).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
            var exit = _mapper.Map<Resultado, ResultadoVOExit>(verify);

            return Ok(exit);
        }
    }
}
