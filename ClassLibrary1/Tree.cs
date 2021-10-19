using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Tree<T>
    {
        private int count = 0;
        public PointTree<T> root = null;
        public int Number
        {
            get
            {
                if (this.root == null) return 0;
                count = 0;
                PointTree<T> p = root;
                Count(p);
                return count;
            }
        }
        private void Count(PointTree<T> p)
        {
            if (p != null)
            {
                count++;
                Count(p.left);
                Count(p.right);
            }
        }
        public PointTree<T> Formation(uint size, PointTree<T> p, ref int count, params T[] mas)
        {
            uint left;
            uint right;
            if (size <= 0)
            {
                p = null;
                return p;
            }
            left = size / 2;
            right = size - left - 1;
            PointTree<T> r = new PointTree<T>(mas[count]);
            count++;
            r.left = Formation(left, r.left, ref count, mas);
            r.right = Formation(right, r.right, ref count, mas);
            return r;
        }
        public Tree() { }
        public Tree(PointTree<T> rootpar)
        {
            root = rootpar;
        }
        public void Write(PointTree<T> p, uint l)
        {
            if (p != null)
            {
                Write(p.left, l + 6);
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.data + "\n");
                Write(p.right, l + 6);
            }
        }
        public void TreeSearch(T znach)
        {
            PointTree<T> p = root;
            while (p != null)
            {
                if (string.Compare(znach.ToString(), p.data.ToString()) < 0)
                {
                    if (p.left == null) break;
                    p = p.left;
                }
                else
                {
                    if (p.right == null) break;
                    p = p.right;
                }
            }
            PointTree<T> NewPoint = new PointTree<T>(znach);
            if (string.Compare(znach.ToString(), p.data.ToString()) < 0)
            {
                p.left = NewPoint;
            }
            else
            {
                p.right = NewPoint;
            }
        }
        public static void LookFor(string surname, PointTree<string> p, Dictionary<string, Person> dt, ref int count)
        {
            if (p != null)
            {
                LookFor(surname, p.left, dt, ref count);
                LookFor(surname, p.right, dt, ref count);
                if (p.data == surname)
                {
                    Console.WriteLine("\nВот этот объект: ");
                    Console.WriteLine(dt[p.data]);
                    count++;
                }
            }
        }
    }
}
