using BrixBank.Services.Interfaces;
using BrixBank.Services.Models;
using System;

using System.Threading.Tasks;

namespace BrixBank.Services.Services
{
    public class LoanRequestServies : ILoanRequestServies
    {


        private readonly ILoanRequestRepository _repository;

        public LoanRequestServies(ILoanRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Reqest(LoanRequestModel loanRequestModel)
        {
            return await _repository.Reqest(loanRequestModel);
        }
    }
}
