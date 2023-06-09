using BackEnd_Clinica.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Clinica.Services
{
    public class Gerador
    {
        private readonly AppDbContext _context;

        public Gerador(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> GerarCadastro()
        {
            long ultimoId = await _context.Pacientes.OrderByDescending(o => o.Id).Select(o => o.Cadastro).FirstOrDefaultAsync();
            Random random = new Random();
            long numeroAleatorio = random.Next(0, 100000000); // Valor aleatório de 9 dígitos
            long numero = 0;
            if (ultimoId == 0)
            {
                numero = long.Parse($"{11111111}{numeroAleatorio:D8}");
            }
            else
            {
                var convertSmall = ultimoId.ToString().Substring(4, 8);
                numero = long.Parse($"{convertSmall:D8}{numeroAleatorio:D8}");
            }
                 // Formata o último ID e o número aleatório

            // Verifica se o número gerado já existe na tabela
            while (await _context.Pacientes.AnyAsync(o => o.Cadastro == numero))
            {
                // Se o número gerado já existe, gera outro número aleatório
                numeroAleatorio = random.Next(0, 1000000000);
                numero = long.Parse($"{ultimoId:D8}{numeroAleatorio:D8}");
            }
            var convert = numero.ToString().Substring(0, 16);
            return long.Parse(convert);
        }
    }
}
