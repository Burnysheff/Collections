using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PointTree<T>
    {
        public T data;
        public PointTree<T> left;
        public PointTree<T> right;
        public PointTree()
        {
            data = default;
            left = null;
            right = null;
        }
        public PointTree(T d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
