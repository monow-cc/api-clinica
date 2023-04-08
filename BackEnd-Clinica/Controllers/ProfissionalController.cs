using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.Services;
using BackEnd_Clinica.VOS.Enter.Profissional;
using BackEnd_Clinica.VOS.Enter.User;
using BackEnd_Clinica.VOS.Exit.Profissional;
using BackEnd_Clinica.VOS.Exit.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public ProfissionalController(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        [HttpPost]
        public async Task<ActionResult<Profissional>> Post(ProfissionalVOEnter profissional)
        {
            var verifyEmail = await _context.Profissional.FirstOrDefaultAsync(e=> e.Email == profissional.Email);
            if (verifyEmail != null) throw new AplicationRequestExeption("Email já cadastrado",HttpStatusCode.Unauthorized);

            var mapper = _mapper.Map<ProfissionalVOEnter, Profissional>(profissional);

            await _context.Profissional.AddAsync(mapper);
            await _context.SaveChangesAsync();
            JWTService jwt = new JWTService(_config);
            var token = new AuthVOExit()
            {
                Token = jwt.GerarTokenProfissional(mapper)
            };
            return Ok(token);
        }
        [HttpPost("auth")]
        public async Task<ActionResult<AuthVOExit>> Auth([FromBody] AuthVOEnter auth)
        {
            if (!ModelState.IsValid) throw new AplicationRequestExeption("Solicitação Invalida", ModelState);


            Profissional? usuario = await _context.Profissional.FirstOrDefaultAsync(u => u.Email == auth.Email);

            if (usuario == null) throw new AplicationRequestExeption("Email Não cadastrado", HttpStatusCode.Unauthorized);

            if (auth.Password != usuario.Password) throw new AplicationRequestExeption("Senha Invalida", HttpStatusCode.Unauthorized);



            JWTService jwt = new JWTService(_config);


            var token = new AuthVOExit()
            {
                Token = jwt.GerarTokenProfissional(usuario)
            };


            return Ok(token);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ProfissionalAuthVOExit>> GetAuthInfo()
        {
            Guid userId = Guid.Parse(HttpContext.Items["Id"]!.ToString()!);
            var get = await _context.Profissional.Include(e => e.Clinicas)!.ThenInclude(c => c.Clinica).FirstOrDefaultAsync(e => e.Id == userId);
            var convert = _mapper.Map<Profissional, ProfissionalAuthVOExit>(get);
            return Ok(convert);
        }

    }
}
