
using SignalRHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRHost.Services
{
    public interface IServices
    {
        public Task<Devices> DevicesConnected();
        public Task<string> SendLogs();
        public Task<string> Health();
    }
}
