using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Collections
    {
        public static int count = 0;
        public List<Person> first = new List<Person>();
        public List<string> second = new List<string>();
        public Dictionary<Person, Student> third = new Dictionary<Person, Student>();
        public Dictionary<string, Student> forth = new Dictionary<string, Student>();
        public Collections()
        {
            for (int i = 0; i < 1000; i++)
            {
                Student a = new Student();
                a = (Student)a.Init();
                Person b = a;
                if (first.Contains(b))
                {
                    b.Name += count.ToString();
                    count++;
                }
                first.Add(b);
                second.Add(b.ToString());
                third.Add(b, a);
                forth.Add(b.ToString(), a);
            }
        }
    }
}
