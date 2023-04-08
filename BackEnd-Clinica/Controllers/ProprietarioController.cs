using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProprietarioController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Proprietario>> Post(Proprietario entity)
        {
            var verify = await _context.Proprietarios.FirstOrDefaultAsync(e => e.Email == entity.Email);
            if(verify != null) throw new AplicationRequestExeption("Email já cadastrado", HttpStatusCode.Unauthorized);
            entity.CreatedAt = DateTime.UtcNow;
            await _context.Proprietarios.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
        
    }
}
