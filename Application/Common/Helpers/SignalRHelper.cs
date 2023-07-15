using Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;

namespace Application.Common.Helpers
{
    public class SignalRHelper : ISignalRHelper
    {
        private readonly HubConnection _connection;

        public SignalRHelper()
        {
            _connection = new HubConnectionBuilder()
                   .WithUrl($"https://localhost:7290/LogHub")
                   .WithAutomaticReconnect()
                   .Build();

            _connection.StartAsync().Wait();
        }

        public async Task SendLog(string _log)
        {
            await _connection.SendAsync("SendMessage", _log);
        }
    }
}
