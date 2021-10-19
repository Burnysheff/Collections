using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ListOne<T> where T : Person
    {
        public Point<T> beg = null;
        public int Length
        {
            get
            {
                if (beg == null) return 0;
                Point<T> temp = beg;
                int length = 1;
                while (temp.next != null)
                {
                    length++;
                    temp = temp.next;
                }
                return length;
            }
        }
        public ListOne() { }
        public ListOne(uint L)
        {
            if (L == 0) return;
            beg = new Point<T>();
            Point<T> p = beg;
            for (int i = 1; i < L; i++)
            {
                Point<T> temp = new Point<T>();
                p.next = temp;
                p = temp;
            }
        }
        public ListOne(params T[] m)
        {
            if (m.Length == 0) return;
            beg = new Point<T>(m[0]);
            Point<T> p = beg;
            for (int i = 1; i < m.Length; i++)
            {
                Point<T> temp = new Point<T>(m[i]);
                p.next = temp;
                p = temp;
            }
        }
        public int Znach
        {
            get
            {
                if (beg == null) return 0;
                Point<T> temp = beg;
                int length = 0;
                while (temp != null)
                {
                    if (temp.data != default) length++;
                    temp = temp.next;
                }
                return length;
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
                Point<T> p = beg;
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
            Point<T> p = beg;
            for (int i = 0; i < pos - 1; i++)
            {
                p = p.next;
            }
            p.next = p.next.next;
        }
    }
}
