
using SignalRHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRHost.Services
{
    public interface IServices
    {
        public Task<Devices> DevicesConnected();
    }
}
