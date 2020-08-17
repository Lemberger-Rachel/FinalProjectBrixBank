using BrixBank.Data.Entities;
using BrixBank.Services.Models;
using AutoMapper;
using BrixBank.webApi.DTO;

namespace BrixBank.webApi.Mappings
{
    public class AutoMapper : Profile {
    public AutoMapper()
    {
        CreateMap<CustomerModel, Customer>();
        CreateMap<Customer, CustomerModel>();
        CreateMap<CustomerDTO, Customer>();
        CreateMap<Customer, CustomerDTO>();
            CreateMap<LoanRequestDTO, LoanRequestModel> ();
            CreateMap<LoanRequestModel, LoanRequestDTO>();

        } 
    }
}
