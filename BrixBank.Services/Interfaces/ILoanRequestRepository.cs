using BrixBank.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrixBank.Services.Interfaces
{
  public  interface ILoanRequestRepository
    {
        Task<bool> Reqest(LoanRequestModel loanRequestModel);
    }
}
