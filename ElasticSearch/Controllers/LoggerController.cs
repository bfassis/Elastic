using ElasticSearch.Dto;
using ElasticSearch.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Controllers
{
    
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILoggerService _loggerService;

        public LoggerController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        [HttpPost]
        [Route("erro/")]
        public async Task<IActionResult> LogErro([FromBody] LoggerRequest loggerRequest)
        {
            if (loggerRequest == null)
                return BadRequest();

            await _loggerService.LogError(loggerRequest);

            return Ok();
        
        }

        [HttpPost]
        [Route("info/")]
        public async Task<IActionResult> LogInformacao([FromBody] LoggerRequest loggerRequest)
        {
            if (loggerRequest == null)
                return BadRequest();

            await _loggerService.LogInformation(loggerRequest);

            return Ok();

        }

        [HttpPost]
        [Route("warning/")]
        public async Task<IActionResult> LogWarning([FromBody] LoggerRequest loggerRequest)
        {
            if (loggerRequest == null)
                return BadRequest();

            await _loggerService.LogWarning(loggerRequest);

            return Ok();

        }

    }
}
