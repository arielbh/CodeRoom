using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankerApplication
{
    public class SnippetProvider : ISnippetProvider
    {
        private readonly IRepository _repository;

        public SnippetProvider(IRepository repository)
        {
            _repository = repository;
        }

        public Snippet GetNext()
        {
            return _repository.GetNext();
        }
    }

    public interface ISnippetProvider
    {
        Snippet GetNext();


    }

}
