using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace RealtimeAuditMonitor.TestProvider
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
               .WithUrl("https://localhost:5001/hubs/audit")
               .Build();

            connection.On<string>("SendAudit", (audit) =>
            {
                Console.WriteLine($"message from server: {audit}");
            });

            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    await connection.StartAsync();

                    break;
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }

            while (true)
            {
                var auditMessage = Console.ReadLine();
                await connection.InvokeAsync("PushAuditToClients", auditMessage);
            }
        }
    }
}
