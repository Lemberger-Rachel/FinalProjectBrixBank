using BrixBank.Data.Entities;

namespace BrixBank.Data
{
     public class RuleNode
    {
        public BaseRule rule { set; get; }
        public RuleNode Left { set; get; }
        public RuleNode Right { set; get; }

    }
}
