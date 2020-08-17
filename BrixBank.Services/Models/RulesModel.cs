using System;
using System.Collections.Generic;
using System.Text;

namespace BrixBank.Services.Models
{
   public class RulesModel
    {
        public int LawsId { get; set; }
        public string Kind { get; set; }
        public string Operator { get; set; }
        public string Output { get; set; }
    }
}
