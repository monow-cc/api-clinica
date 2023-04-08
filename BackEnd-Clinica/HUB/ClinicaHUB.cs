using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace BackEnd_Clinica.HUB
{
    public class ClinicaHUB : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            
            var getToken = httpContext?.Request.Query["token"];

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(getToken);

            var clinicaId = token.Claims.FirstOrDefault(c => c.Type == "clinicaId")?.Value;
     
            if (clinicaId != null)
                await Groups.AddToGroupAsync(Context.ConnectionId, clinicaId.ToString());

            await Clients.Client(Context.ConnectionId).SendAsync("stateChanged",Context.ConnectionId.ToString());

            await base.OnConnectedAsync();
            
        }
    }
}
