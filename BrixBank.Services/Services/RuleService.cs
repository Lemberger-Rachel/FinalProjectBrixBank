using BrixBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrixBank.Services.Services
{
    public class RuleService : IRuleService
    {

        private readonly IRuleRepository _repository;
        public RuleService(IRuleRepository repository)
        {
            _repository = repository;
        }
        public  void ReadExcelFile()
        {
             _repository.ReadExcelFile();
        }

       
       

      
    }
}
