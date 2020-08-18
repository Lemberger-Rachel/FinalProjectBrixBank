using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrixBank.Data.Entities
{
    public enum Citizen
    {
        Israeli, American, French
    }
   public class LoanRequest
    {
       
        public int Id { get; set; }
        public string LoanRequestrId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Criterion]
        //public int Salary { get; set; }
        //[Criterion]
        //public int Age { get; set; }
        //[Criterion]
        //public Citizen GetCitizen { get; set; }
        [NotMapped]
        public Dictionary<string,int> dictionaryData { get; set; }
        public int LoanSupplied { get; set; }

    }
}
