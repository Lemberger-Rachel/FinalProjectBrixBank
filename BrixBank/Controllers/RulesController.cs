using AutoMapper;
using BrixBank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace BrixBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {

        private readonly IRuleService _RuleService;
    
        private readonly IMapper _mapper;

        public RulesController(IMapper mapper, IRuleService RuleService)
        {
            _RuleService = RuleService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("{action}")]
        public void ReadExcel()
        {
            try
            {
                _RuleService.ReadExcelFile();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

