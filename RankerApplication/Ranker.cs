using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankerApplication
{
    public interface IRanker
    {
        void Start();
        void Stop();
    }

    public class Ranker : IRanker
    {
        private readonly ISnippetProvider _snippetProvider;
        private readonly IRuleEngineProvider _ruleEngineProvider;
        private readonly IRepository _repository;
        private bool working;

        public Ranker(ISnippetProvider snippetProvider, IRuleEngineProvider ruleEngineProvider, IRepository repository)
        {
            _snippetProvider = snippetProvider;
            _ruleEngineProvider = ruleEngineProvider;
            _repository = repository;
        }

        public void Start()
        {
            working = true;
            Task.Factory.StartNew(Work);

        }

        private void Work()
        {
            while (working)
            {
                var snippet = _snippetProvider.GetNext();
                var ruleEngine = _ruleEngineProvider.GetRuleEngineByLanguage(snippet.Language);
                var rank = ruleEngine.Rank(snippet);
                snippet.Rank = rank;
                _repository.Save(snippet);
            }
        }

        public void Stop()
        {
            working = false;


        }

    }

    public interface IRuleEngineProvider
    {
        IRuleEngine GetRuleEngineByLanguage(Languages language);
    }

    public  interface IRuleEngine
    {
        int Rank(Snippet snippet);
    }
}
