using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Employee : Person, INit
    {
        Random rnd = new Random();
        public static int kolichestvo = 0;
        private uint salary;
        private uint years;
        public uint Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public uint Years
        {
            get { return years; }
            set { years = value; }
        }
        public Employee(string name = "Не указано", string surname = "Не указана", uint age = 0, uint salary = 0, uint years = 0) : base(name, surname, age)
        {
            kolichestvo++;
            Years = years;
            Salary = salary;
        }
        public new void Show()
        {
            Console.WriteLine($"\nСотрудник.\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nЗарплата: {Salary}\nКоличество лет на работе: {Years}\n");
        }
        override public void Write()
        {
            Console.WriteLine($"\nСотрудник.\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nЗарплата: {Salary}\nКоличество лет на работе: {Years}\n");
        }
        public override object Init()
        {
            Person p = (Person)base.Init();
            Person.count--;
            Employee e = new Employee(p.Name, p.Surname, p.Age, (uint)rnd.Next(100000), (uint)rnd.Next(30));
            return e;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && (((Employee)obj).Salary == this.Salary) && (((Employee)obj).Years == this.Years);
        }
    }
}
