using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PointDir<T> where T : Person
    {
        public T data;
        public PointDir<T> next;
        public PointDir<T> prev;
        public PointDir()
        {
            data = (T)new Person();
            next = null;
            prev = null;
        }
        public PointDir(T d)
        {
            data = d;
            next = null;
            prev = null;
        }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
