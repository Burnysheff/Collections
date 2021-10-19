using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ListDir<T> where T : Person
    {
        public PointDir<T> beg = null;
        public int Length
        {
            get
            {
                if (beg == null) return 0;
                PointDir<T> temp = beg;
                int length = 1;
                while (temp.next != null)
                {
                    length++;
                    temp = temp.next;
                }
                return length;
            }
        }
        public ListDir() { }
        public ListDir(uint L)
        {
            if (L == 0) return;
            beg = new PointDir<T>();
            PointDir<T> p = beg;
            for (int i = 1; i < L; i++)
            {
                PointDir<T> temp = new PointDir<T>();
                temp.prev = p;
                p.next = temp;
                p = temp;
            }
        }
        public ListDir(params T[] m)
        {
            if (m.Length == 0) return;
            beg = new PointDir<T>(m[0]);
            PointDir<T> p = beg;
            for (int i = 1; i < m.Length; i++)
            {
                PointDir<T> temp = new PointDir<T>(m[i]);
                temp.prev = p;
                p.next = temp;
                p = temp;
            }
        }
        public void Write()
        {
            if (this.Length == 0)
            {
                Console.WriteLine("\nСписок пустой!");
                return;
            }
            else
            {
                PointDir<T> p = beg;
                for (int i = 0; i < this.Length; i++)
                {
                    Console.WriteLine(p.ToString());
                    Console.WriteLine();
                    p = p.next;
                }
            }
        }
        public void Delete(int pos)
        {
            if (pos > this.Length)
            {
                Console.WriteLine("\nТакой позиции нет!");
                return;
            }
            PointDir<T> p = beg;
            for (int i = 0; i < pos - 1; i++)
            {
                p = p.next;
            }
            p.next = p.next.next;
        }
        public void Add(T dop, uint pos)
        {
            PointDir<T> p = beg;
            if (pos > this.Length + 1)
            {
                Console.WriteLine("\nМожно поставить только на позицию из списка или в его конец!\n");
                return;
            }
            if (this.Length == 0)
            {
                PointDir<T> pn = new PointDir<T>(dop);
                beg = pn;
                return;
            }
            if (pos == this.Length + 1)
            {
                while (p.next != null)
                {
                    p = p.next;
                }
                PointDir<T> pn = new PointDir<T>(dop);
                p.next = pn;
                pn.prev = p;
                return;
            }
            if (pos == 1)
            {
                PointDir<T> pn = new PointDir<T>(dop);
                pn.next = p;
                p.prev = pn;
                beg = pn;
                return;
            }
            for (int i = 0; i < pos - 2; i++)
            {
                p = p.next;
            }
            PointDir<T> pt = new PointDir<T>(dop);
            p.next.prev = pt;
            pt.next = p.next;
            p.next = pt;
            pt.prev = p;
        }
    }
}
