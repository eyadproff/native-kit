using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRHost.Models;
using SignalRHost.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NativeKitController : ControllerBase
    {
        private readonly IDeviceServices deviceServices;
        public NativeKitController(IDeviceServices device)
        {
            deviceServices = device;
        }

        [HttpGet("allDevicesConnected")]
        public async Task<ActionResult<List<DeviceDetails>>> DevicesConnected()
        {
            return await deviceServices.DevicesConnected();
        }
    }
}
