using BrixBank.Data.Entities;

namespace BrixBank.webApi.DTO
{
    public class LoanRequestDTO
    {
        public int Id { get; set; }
        public string LoanRequestrId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public Citizen GetCitizen { get; set; }
        public int LoanSupplied { get; set; }

    }

}
