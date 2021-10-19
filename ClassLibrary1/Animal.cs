using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Number
    {
        public static uint count = 1;
        public uint number;
        public Number(uint a)
        {
            number = a;
            count++;
        }
    }
    public class Animal : INit, ICloneable
    {
        public Number number;
        Random rnd = new Random();
        public string Name { get; set; }
        public string Colour { get; set; }
        public uint Age { get; set; }
        public Animal(string a, string b, uint c, uint d)
        {
            Name = a;
            Colour = b;
            Age = c;
            number = new Number(d);
        }
        public Animal()
        {
            Name = "lion";
            Colour = "yellow";
            Age = 10;
            number = new Number(Number.count);
        }
        public object Init()
        {
            string[] names = { "lion", "fish", "rabbit", "unicorn", "dog", "squirrel", "bear", "whale" };
            string[] colors = { "red", "green", "yellow", "pink", "white", "black", "party colour", "cyan" };
            Animal an = new Animal(names[rnd.Next(names.Length)], colors[rnd.Next(colors.Length)], (uint)rnd.Next(30), Number.count);
            return an;
        }
        public object Clone()
        {
            return new Animal(this.Name, this.Colour, this.Age, this.number.number);
        }
        public void Write()
        {
            Console.WriteLine($"\nЖивотное\nВид животного: {Name}\nЕго цвет: {Colour}\nЕго возраст: {Age} лет\nЕго номер: {number.number}\n");
        }
        public Animal Copy()
        {
            return (Animal)this.MemberwiseClone();
        }
    }
}
