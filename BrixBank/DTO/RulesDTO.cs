using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrixBank.webApi.DTO
{
    public class RulesDTO
    {
        public int LawsId { get; set; }
        public string Kind { get; set; }
        public string Operator { get; set; }
        public string Output { get; set; }
        public string Rules { get; set; }
    }
}
