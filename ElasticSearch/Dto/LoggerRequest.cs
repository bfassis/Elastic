using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Dto
{
    public class LoggerRequest
    {
        public string Aplicacao { get; set; }
        public string Mensagem  { get; set; }
        public string MensagemInterna { get; set; }
        public string Stacktrace { get; set; }
    }
}
