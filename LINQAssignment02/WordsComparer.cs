using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment02
{
    internal class WordsComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x == null || y == null)
            { 
                return false; 
            }
            else
            {
                return x.OrderBy(c => c).SequenceEqual(y.OrderBy(c => c));
            }
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return String.Concat(obj.OrderBy(c => c)).GetHashCode();

        }
    }
}
