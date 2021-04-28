using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodinimoUzduotis.Models
{
    public class Response
    {
        public string output { get; set; }
        public string statusCode { get; set; }
        public string memory { get; set; }
        public string cpuTime { get; set; }
    }
}
