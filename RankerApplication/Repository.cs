using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankerApplication
{
    public class Repository : IRepository
    {
        public Snippet GetNext()
        {
            throw new NotImplementedException();

        }

        public void Save(Snippet snippet)
        {
            throw new NotImplementedException();
        }
    }

    public  interface IRepository
    {
        Snippet GetNext();
        void Save(Snippet snippet);
    }
}
