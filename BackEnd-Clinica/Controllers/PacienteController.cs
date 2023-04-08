using AutoMapper;
using BackEnd_Clinica.Atribute;
using BackEnd_Clinica.Context;
using BackEnd_Clinica.Exeption;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Paciente;
using BackEnd_Clinica.VOS.Exit.Paciente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;

namespace BackEnd_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PacienteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost("clinica")]
        public async Task<ActionResult<PacienteVOExit>> Post(PacienteVOEnter entity)
        {
            Guid clinicaId = Guid.Parse(HttpContext.Items["ClinicaId"]!.ToString()!);//Pega id da clinica no token
            var verify = await _context.Pacientes.FirstOrDefaultAsync(e => e.Cpf ==  entity.Cpf); // verifica se a conta esta cadastrada
            if (verify != null) throw new AplicationRequestExeption("CPF já esta cadastrado", HttpStatusCode.Unauthorized); // retorna erro
            var verifyClinica = await _context.PacientesClinica.Include(i => i.Paciente).Where(i => i.ClinicaId == clinicaId && i.Paciente.Cpf == entity.Cpf).FirstOrDefaultAsync(); // verifica se o paciente ja esta na clinica
            if (verifyClinica != null) throw new AplicationRequestExeption("Paciente ja esta cadastrado em sua clinica", HttpStatusCode.Unauthorized);// retorna erro

            var paciente = _mapper.Map<PacienteVOEnter,Paciente>(entity); // converte entrada para model
            paciente.Password = GetRandomPassword(10); // cria uma senha randomica


            await _context.Pacientes.AddAsync(paciente); // adicioanr
            await _context.SaveChangesAsync(); // salva

            if (entity.AdicionarClinica)
            {
                //var newCP = new PacienteClinica()
                //{
                //    ClinicaId = clinicaId,
                //    PacienteId = paciente.Id
                //};
                //await _context.PacientesClinica.AddAsync(newCP);
                //await _context.SaveChangesAsync();
            }
            return Ok(paciente); // retorna para o response
        }
        public static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}
