
namespace BrixBank.Data.Entities
{
    public class BaseRule
    {
        public string Operator { set; get; }

    }
    public class Rules:BaseRule
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public int Output { get; set; }
        public string Law { get; set; }
        public virtual Customer CustomerId2 { get; set; }

    }
}
