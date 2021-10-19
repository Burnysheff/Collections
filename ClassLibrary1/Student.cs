using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Student : Person, INit
    {
        Random rnd = new Random();
        public static int kolichestvo = 0;
        private uint course;
        private double avMark;
        public uint Course
        {
            get { return course; }
            set
            {
                if (value > 6)
                {
                    Console.WriteLine("Такого курса не может быть! Наверное он на 4-м курсе");
                    course = 4;
                }
                else course = value;
            }
        }
        public double AvMark
        {
            get { return avMark; }
            set { avMark = value; }
        }

        public Student(string name = "Не указано", string surname = "Не указана", uint age = 0, uint course = 0, double avmark = 0) : base(name, surname, age)
        {
            kolichestvo++;
            Course = course;
            AvMark = avmark;
        }
        public new void Show()
        {
            Console.WriteLine($"\nСтудент.\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nКурс: {Course}\nСредняя оценка: {AvMark}\n");
        }
        override public void Write()
        {
            Console.WriteLine($"\nСтудент.\nИмя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nКурс: {Course}\nСредняя оценка: {AvMark}\n");
        }
        public override object Init()
        {
            Person p = (Person)base.Init();
            Person.count--;
            Student s = new Student(p.Name, p.Surname, p.Age, (uint)rnd.Next(1, 6), (double)rnd.Next(1, 10));
            return s;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj) && (((Student)obj).Course == this.Course) && (((Student)obj).AvMark == this.AvMark);
        }
    }
}
