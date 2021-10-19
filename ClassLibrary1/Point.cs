using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Point<T> where T : Person
    {
        public T data;
        public Point<T> next;
        public Point()
        {
            data = (T)new Person();
            next = null;
        }
        public Point(T d)
        {
            data = d;
            next = null;
        }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
