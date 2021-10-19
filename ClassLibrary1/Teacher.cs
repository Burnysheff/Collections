using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Teacher : Person, INit
    {
        Random rnd = new Random();
        private string discipline;
        private uint kolStud;
        public string Discipline
        {
            get { return discipline; }
            set
            {
                if (value.Trim() == "")
                {
                    Console.WriteLine("\nВы решили не указвать дисциплину");
                    discipline = "Не указано";
                }
                else discipline = value;
            }
        }
        public uint KolStud
        {
            get { return kolStud; }
            set { kolStud = value; }
        }
        public Teacher(string name = "Не указано", string surname = "Не указана", uint age = 0, string discipline = "не указано", uint kolStud = 0) : base(name, surname, age)
        {
            KolStud = kolStud;
            Discipline = discipline;
        }
        public new void Show()
        {
            Console.WriteLine($"\nПреподаватель.\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nДисциплина: {Discipline}\nКоличество обучаемых студентов: {KolStud}\n");
        }
        override public void Write()
        {
            Console.WriteLine($"\nПреподаватель.\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nДисциплина: {Discipline}\nКоличество обучаемых студентов: {KolStud}\n");
        }
        public override object Init()
        {
            string[] disciplines = { "maths", "programming", "history", "biology", "geography", "physics", "chemistry" };
            Person p = (Person)base.Init();
            Person.count--;
            Teacher t = new Teacher(p.Name, p.Surname, p.Age, disciplines[rnd.Next(disciplines.Length)], (uint)rnd.Next(300));
            return t;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && (((Teacher)obj).KolStud == this.KolStud) && (((Teacher)obj).Discipline == this.Discipline);
        }
    }
}
