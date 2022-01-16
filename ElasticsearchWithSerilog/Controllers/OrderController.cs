using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace ElasticsearchWithSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger _logger;
        public OrderController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var ran = new Random();
                if (ran.Next(0, 5) < 2)
                {
                    throw new Exception("Oop what happened?");
                }
                return Ok("Create order");
            }
            catch (Exception e)
            {
                _logger.Error(e,"Something bad happened {CustomProperty}",100);
                return new StatusCodeResult(500);
            }
        }
    }
}