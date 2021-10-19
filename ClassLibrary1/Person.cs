using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Person : INit, IComparable
    {
        Random rnd = new Random();
        private string name;
        private string surname;
        private uint age;
        public static int count;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Trim() == "")
                {
                    Console.WriteLine("\nВы решили не указвать имя");
                    name = "Не указано";
                }
                else name = value;
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value.Trim() == "")
                {
                    Console.WriteLine("\nВы решили не указывать фамилию");
                    surname = "Не указана";
                }
                else surname = value;
            }
        }
        public uint Age
        {
            get { return age; }
            set { age = value; }
        }
        public Person(string name = "Не указано", string surname = "Не указана", uint age = 0)
        {
            count++;
            Name = name;
            Surname = surname;
            Age = age;
        }
        public void Show()
        {
            Console.WriteLine($"\nПросто человек\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\n");
        }
        virtual public void Write()
        {
            Console.WriteLine($"\nПросто человек\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\n");
        }
        public virtual object Init()
        {
            int c;
            int d;
            string[] names = { "Nikolay", "Alexei", "Andrei", "Nikita", "Alexandr", "Daniil", "Denis", "Daria", "Maria", "Kristina", "Anna", "Yulia", "Eva", "Viktoria" };
            string[] surnames = { "Petrov", "Smirnov", "Ivanov", "Chernov", "Belov", "Krasnov", "Orlov", "Petrova", "Smirnova", "Ivanova", "Chernova", "Belova", "Krasnova", "Orlova" };
            c = rnd.Next(names.Length);
            if (c > 6)
            {
                d = rnd.Next(7, surnames.Length);
            }
            else d = rnd.Next(0, 7);
            string a = names[c];
            string b = surnames[d];
            Person p = new Person(a, b, (uint)rnd.Next(1, 100));
            return p;
        }
        public int CompareTo(object obj)
        {
            if (this.Age > ((Person)obj).age) return 1;
            if (this.Age < ((Person)obj).age) return -1;
            return 0;
        }
        public override bool Equals(object obj)
        {
            return (this.Name == ((Person)obj).Name && this.Surname == ((Person)obj).Surname && this.Age == ((Person)obj).Age);
        }
    }
}
