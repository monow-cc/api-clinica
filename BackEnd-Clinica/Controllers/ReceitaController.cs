using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Receita;
using BackEnd_Clinica.VOS.Enter.TratamentoClinica;
using BackEnd_Clinica.VOS.Exit.Receita;
using BackEnd_Clinica.VOS.Exit.TratamentoClinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ReceitaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Receita>> Post(ReceitaVOEnter entity)
        {
            var map = _mapper.Map<ReceitaVOEnter, Receita>(entity);
            map.Created_At = DateTime.Now;
            await _context.Receitas.AddAsync(map);
            await _context.SaveChangesAsync();
            var convert = _mapper.Map<Receita, ReceitaVOExit>(map);
            return Ok(convert);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<TratamentoClinicaVOExit>> Delete(Guid id)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);// pega clinica no token

            var verify = await _context.Receitas.Where(e => e.Id == id).FirstOrDefaultAsync();
            
            _context.Receitas.Entry(verify).State = EntityState.Deleted;
            
            await _context.SaveChangesAsync();
            var exit = _mapper.Map<Receita, ReceitaVOExit>(verify);

            return Ok(exit);
        }
    }
}
