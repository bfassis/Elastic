using ElasticSearch.Dto;
using ElasticSearch.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;

        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }

        public async Task LogError(LoggerRequest request)
        {
                var data = DateTime.UtcNow;
                using (LogContext.PushProperty("Aplicacao", request.Aplicacao))
                using (LogContext.PushProperty("Mensagem", request.Mensagem))
                using (LogContext.PushProperty("MensagemInterna", request.MensagemInterna))
                using (LogContext.PushProperty("Stacktrace", request.Stacktrace))
                using (LogContext.PushProperty("Data", data))
                {
                    await Task.Run(() => _logger.LogError($"Log: Aplicação: {request.Aplicacao} - Mensagem: {request.Mensagem} -" +
                        $" MensagemInterna: {request.MensagemInterna} - Stacktrace: {request.Stacktrace} - Data: {data}"));
                }                        

        }

        public async Task LogInformation(LoggerRequest request)
        {
            var data = DateTime.UtcNow;
            using (LogContext.PushProperty("Aplicacao", request.Aplicacao))
            using (LogContext.PushProperty("Mensagem", request.Mensagem))
            using (LogContext.PushProperty("Data", data))
            {
                await Task.Run(() => _logger.LogInformation($"Log: Aplicação:{request.Aplicacao} - Mensagem: {request.Mensagem} - Data: {data}"));
            }
        }

        public async Task LogWarning(LoggerRequest request)
        {
            var data = DateTime.UtcNow;
            using (LogContext.PushProperty("Aplicacao", request.Aplicacao))
            using (LogContext.PushProperty("Mensagem", request.Mensagem))
            using (LogContext.PushProperty("Data", data))
            {
                await Task.Run(() => _logger.LogWarning($"Log: Aplicação:{request.Aplicacao} - Mensagem: {request.Mensagem} - Data: {data}"));
            }
        }
    }
}
