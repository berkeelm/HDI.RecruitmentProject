using Microsoft.AspNetCore.SignalR;

namespace WebUI.Hubs
{
    public class LogHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            System.Console.WriteLine("Yeni bir bağlantı: " + Context.ConnectionId);
            Clients.All.SendAsync("YeniBaglanti", "Yeni bir giriş algılandı.", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string mesaj)
        {
            await Clients.All.SendAsync("BirMesajVar", mesaj);
        }

        public override Task OnDisconnectedAsync(System.Exception? exception)
        {
            System.Console.WriteLine("Kapatılan bağlantı: " + Context.ConnectionId);
            Clients.All.SendAsync("KapatilanBaglanti", "Bağlantı kapatıldı.", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
