using AutoMapper;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.HUB;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.Services;
using BackEnd_Clinica.VOS.Enter.User;
using BackEnd_Clinica.VOS.Exit.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Net;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IHubContext<ClinicaHUB> _hubContext;

        public UserController(AppDbContext context, IConfiguration config, IMapper mapper, IHubContext<ClinicaHUB> hubContext)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
            _hubContext = hubContext;
        }
        [HttpPost]
        public async Task<ActionResult<AuthVOExit>> Post(UserVOEnter userVo)
        {
            var verify = await _context.Users.FirstOrDefaultAsync(e => e.Email == userVo.Email);
            if (verify != null) throw new AplicationRequestExeption("Email já cadastrado", HttpStatusCode.Unauthorized);
            User user = _mapper.Map<UserVOEnter, User>(userVo);
            user.CreatedAt = DateTime.UtcNow;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            JWTService jwt = new JWTService(_config);


            var token = new AuthVOExit()
            {
                Token = jwt.GerarToken(user)
            };


            return Ok(token);
        }
        [HttpPost("auth")]
        public async Task<ActionResult<AuthVOExit>> Auth([FromBody] AuthVOEnter auth)
        {
            if (!ModelState.IsValid) throw new AplicationRequestExeption("Solicitação Invalida", ModelState);

           

            User? usuario = await _context.Users.Include(c => c.Clinica).FirstOrDefaultAsync(u => u.Email == auth.Email);

            if (usuario == null) throw new AplicationRequestExeption("Email Não cadastrado", HttpStatusCode.Unauthorized);

            if (auth.Password != usuario.Password) throw new AplicationRequestExeption("Senha Invalida", HttpStatusCode.Unauthorized);

            

            JWTService jwt = new JWTService(_config);


            var token = new AuthVOExit()
            {
                Token = jwt.GerarToken(usuario)
            };
            await _hubContext.Clients.Group(usuario.ClinicaId.ToString()).SendAsync("userconnect", $"Usuario: {usuario.Nome} Conectado na clinica");

            return Ok(token);
        }
    }
}
