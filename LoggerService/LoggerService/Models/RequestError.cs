using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Model
{
    public class RequestError
    {
        public string Message { get; set; }
        public string StackTrace{ get; set; }
    }
}
