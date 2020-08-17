using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrixBank.Services.Interfaces;
using BrixBank.Services.Models;
using BrixBank.webApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BrixBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanRequestController : ControllerBase
    {
        private readonly ILoanRequestServies _service;
        private readonly IMapper _mapper;
        public LoanRequestController(ILoanRequestServies service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{action}")]
        public void TryMe()
        {
        
           
        } 
        [HttpPost]
        public async Task<bool> LoanRequestFor([FromBody] LoanRequestDTO loanRequestDTO)
        {
            try
            {
                return await _service.Reqest(_mapper.Map <LoanRequestModel> (loanRequestDTO));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       
    }
}
