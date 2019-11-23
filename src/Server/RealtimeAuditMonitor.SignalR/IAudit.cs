using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeAuditMonitor.SignalR
{
    public interface IAudit
    {
        Task SendAudit(string message);
    }
}
