using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankerApplication
{
    public enum Languages
    {
        CSharp,
        Java
    }
    public class Snippet
    {
        public Languages Language { get; set; }

        public int Rank { get; set; }
    }
}
