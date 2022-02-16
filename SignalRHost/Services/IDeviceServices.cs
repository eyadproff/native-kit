
using SignalRHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRHost.Services
{
    public interface IDeviceServices
    {
        public Task<Devices> DevicesConnected();
    }
}
