using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankerApplication
{
    public class RuleEngine : IRuleEngine
    {
        public RuleEngine(IRule[] rules)
        {
            Rules = rules;
        }

        public int Rank(Snippet snippet)
        {
            if (Rules.Length == 0) throw new Exception("Meh");
            
            int result = 0;
            foreach (var rule in Rules)
            {
                result = Convert.ToInt32(Math.Floor(rule.Rank(snippet) * rule.Weight));
            }
            return result;
        }



        public IRule[] Rules { get; private set; }

    }

    public interface IRule
    {
        int Rank(Snippet snippet);
        double Weight { get; set; }

    }
}
