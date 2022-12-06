using ElasticSearch.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Interfaces
{
    public interface ILoggerService
    {
        Task LogInformation(LoggerRequest request);
        Task LogWarning(LoggerRequest request);
        Task LogError(LoggerRequest request);            
     }
}
