using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class SortBySurname : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            return string.Compare(((Person)obj1).Surname, ((Person)obj2).Surname);
        }
    }
}
