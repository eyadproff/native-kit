using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRHost.Models;
using SignalRHost.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using SignalRHost.Utilities;

namespace SignalRHost.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NativeKitController : ControllerBase
    {
        private readonly IServices _services;
        public NativeKitController(IServices services)
        {
            _services = services;
        }

        [HttpGet("list")]
        public async Task<ActionResult<Devices>> DevicesConnected()
        {
            return await _services.DevicesConnected();
        }

        [HttpGet("logs")]
        public Task<string> SendLogs()
        {
            return _services.SendLogs();
        }

    }
}
