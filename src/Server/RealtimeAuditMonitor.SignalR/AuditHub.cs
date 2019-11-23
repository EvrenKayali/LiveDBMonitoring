using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeAuditMonitor.SignalR
{
    public class AuditHub : Hub<IAudit>
    {
        public async Task PushAuditToClients(string message)
        {
            await Clients.All.SendAudit(message);
        }
    }
}
