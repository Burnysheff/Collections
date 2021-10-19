using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Collections;
using System.Diagnostics;

namespace ConsoleApp11
{
    class Program
    {
        public static void Poisk(Queue q)
        {
            if (q.Count == 0)
            {
                Console.WriteLine("\nОчередь пустая!\n");
                return;
            }
            ArrayList a = new ArrayList(q);
            Console.WriteLine("\nВведите, пожалуйста, фамилию человека: ");
            string buf = Console.ReadLine();
            Person p = new Person(surname: buf);
            Person.count--;
            int pos = a.BinarySearch(p, new SortBySurname());
            if (pos < 0)
            {
                Console.WriteLine("\nЧеловека с такой фамилией не найдено!\n");
                return;
            }
            else
            {
                Console.WriteLine($"\nЭтот человек находится на позиции {pos + 1}\n\nА вот и он: ");
                Person per = (Person)a[pos];
                per.Write();
            }
        }
        public static void Poisk(Dictionary<string, Person> d)
        {
            if (d.Count == 0)
            {
                Console.WriteLine("\nСловарь пустой!\n");
                return;
            }
            ArrayList a = new ArrayList(d.Values);
            Person[] mas = new Person[d.Keys.Count];
            for (int i = 0; i < d.Keys.Count; i++)
            {
                mas[i] = (Person)a[i];
            }
            Console.WriteLine("\nВведите, пожалуйста, возраст человека: ");
            ProvUint(out uint age);
            Person p = new Person(age: age);
            Person.count--;
            int pos = Array.BinarySearch(mas, p);
            if (pos < 0)
            {
                Console.WriteLine("\nЧеловека такого возраста не найдено!\n");
                return;
            }
            else
            {
                Console.WriteLine($"\nЭтот человек находится на позиции {pos + 1}\n\nА вот и он: ");
                Person per = mas[pos];
                per.Write();
            }
        }
        public static void Sort(ref Dictionary<string, Person> d)
        {
            if (d.Count == 0)
            {
                Console.WriteLine("\nСловарь пустой!\n");
                return;
            }
            ArrayList a = new ArrayList(d.Values);
            a.Sort(new SortBySurname());
            Dictionary<string, Person> ag = new Dictionary<string, Person>();
            for (int i = 0; i < a.Count; i++)
            {
                ag.Add(((Person)a[i]).Surname, (Person)a[i]);
            }
            d = ag;
            Console.WriteLine("\nПолучившийся словарь: ");
            foreach (KeyValuePair<string, Person> keyValue in d)
            {
                Console.WriteLine($"\nФамилия человека:\n{keyValue.Key}\n\nЕго данные:");
                keyValue.Value.Write();
                Console.WriteLine("\n");
            }
        }
        public static void Sort(ref Queue q)
        {
            if (q.Count == 0)
            {
                Console.WriteLine("\nОчередь пустая!\n");
                return;
            }
            ArrayList a = new ArrayList(q);
            a.Sort(new SortBySurname());
            q = new Queue(a);
            foreach (Person p in q) p.Write();
        }
        public static void RandomSozdanie(ref Queue q)
        {
            int men = 0;
            Console.WriteLine("\n1. Создать преподавателя");
            Console.WriteLine("2. Создать студента");
            Console.WriteLine("3. Создать сотрудника");
            Console.WriteLine("4. Создать просто человека");
            Console.WriteLine("5. Создать животное (вне иерархии классов)");
            ProvMenu(ref men, 0, 6);
            switch (men)
            {
                case 1:
                    Teacher t = new Teacher();
                    Person.count--;
                    Teacher ter = (Teacher)t.Init();
                    q.Enqueue(ter);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
                case 2:
                    Student s = new Student();
                    Person.count--;
                    Student ser = (Student)s.Init();
                    q.Enqueue(ser);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
                case 3:
                    Employee e = new Employee();
                    Person.count--;
                    Employee eer = (Employee)e.Init();
                    q.Enqueue(eer);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
                case 4:
                    Person p = new Person();
                    Person.count--;
                    Person per = (Person)p.Init();
                    q.Enqueue(per);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
                case 5:
                    Animal an = new Animal();
                    Number.count--;
                    an = (Animal)an.Init();
                    q.Enqueue(an);
                    Console.WriteLine("\nЖивотное создано!\n");
                    break;
            }
        }
        public static void RandomSozdanie(ref Dictionary<string, Person> d, ref int Index)
        {
            int men = 0;
            Console.WriteLine("\n1. Создать преподавателя");
            Console.WriteLine("2. Создать студента");
            Console.WriteLine("3. Создать сотрудника");
            Console.WriteLine("4. Создать просто человека");
            ProvMenu(ref men, 0, 5);
            switch (men)
            {
                case 1:
                    Teacher t = new Teacher();
                    Person.count--;
                    Teacher ter = (Teacher)t.Init();
                    if (d.ContainsKey(ter.Surname)) { ter.Surname += Index.ToString(); Index++; }
                    d.Add(ter.Surname, ter);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
                case 2:
                    Student s = new Student();
                    Person.count--;
                    Student ser = (Student)s.Init();
                    if (d.ContainsKey(ser.Surname)) { ser.Surname += Index.ToString(); Index++; }
                    d.Add(ser.Surname, ser);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
                case 3:
                    Employee e = new Employee();
                    Person.count--;
                    Employee eer = (Employee)e.Init();
                    if (d.ContainsKey(eer.Surname)) { eer.Surname += Index.ToString(); Index++; }
                    d.Add(eer.Surname, eer);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
                case 4:
                    Person p = new Person();
                    Person.count--;
                    Person per = (Person)p.Init();
                    if (d.ContainsKey(per.Surname)) { per.Surname += Index.ToString(); Index++; }
                    d.Add(per.Surname, per);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    break;
            }
        }
        public static void Clonirovanie(Queue q)
        {
            Queue cl = (Queue)q.Clone();
            Console.WriteLine("\nКлон создан!");
            if (q.Count != 0)
            {
                Console.WriteLine("\nСама коллекция: ");
                foreach (Person p in q) p.Write();
                Console.WriteLine($"\nВсего {q.Count} элементов");
                Console.WriteLine("\nКлон коллекции: ");
                foreach (Person p in cl) p.Write();
                Console.WriteLine($"\nВсего {cl.Count} элементов");
                Console.WriteLine("\n\nТеперь добавим один элемент к клону коллекции и посмотрим что получится: ");
                cl.Enqueue(new Person().Init());
                Person.count--;
                Console.WriteLine("\nСама коллекция: ");
                foreach (Person p in q) p.Write();
                Console.WriteLine($"\nВсего {q.Count} элементов");
                Console.WriteLine("\nКлон коллекции: ");
                foreach (Person p in cl) p.Write();
                Console.WriteLine($"\nВсего {cl.Count} элементов\n");
            }
            else Console.WriteLine("\nПолучились две пустые коллекции...\n");
        }
        public static void Clonirovanie(Dictionary<string, Person> d)
        {
            Dictionary<string, Person> cl = new Dictionary<string, Person>(d);
            Console.WriteLine("\nКлон создан!");
            if (cl.Count != 0)
            {
                Console.WriteLine("\nСама коллекция: \n");
                foreach (KeyValuePair<string, Person> keyValue in d)
                {
                    Console.WriteLine($"\nФамилия человека:\n {keyValue.Key}\n\nЕго данные:");
                    keyValue.Value.Write();
                    Console.WriteLine("\n");
                }
                Console.WriteLine($"\nВсего {d.Count} элементов");
                Console.WriteLine("\nКлон коллекции:\n");
                foreach (KeyValuePair<string, Person> keyValue in cl)
                {
                    Console.WriteLine($"\nФамилия человека:\n {keyValue.Key}\n\nЕго данные:");
                    keyValue.Value.Write();
                    Console.WriteLine("\n");
                }
                Console.WriteLine($"\nВсего {cl.Count} элементов");
                Console.WriteLine("\n\nТеперь добавим один элемент к клону и посмотрим, что выйдет: ");
                Person p = new Person(name: "Andrei", surname: "Bykov", age: 25);
                cl.Add(p.Surname, p);
                Person.count--;
                Console.WriteLine("\nСама коллекция: \n");
                foreach (KeyValuePair<string, Person> keyValue in d)
                {
                    Console.WriteLine($"\nФамилия человека:\n {keyValue.Key}\n\nЕго данные:");
                    keyValue.Value.Write();
                    Console.WriteLine("\n");
                }
                Console.WriteLine($"\nВсего {d.Count} элементов");
                Console.WriteLine("\nКлон коллекции:\n");
                foreach (KeyValuePair<string, Person> keyValue in cl)
                {
                    Console.WriteLine($"\nФамилия человека:\n {keyValue.Key}\n\nЕго данные:");
                    keyValue.Value.Write();
                    Console.WriteLine("\n");
                }
                Console.WriteLine($"\nВсего {cl.Count} элементов");
            }
            else Console.WriteLine("\nПолучились две пустые коллекции...\n");
        }
        public static void Ages(Queue q)
        {
            uint sum = 0;
            if (q.Count == 0)
            {
                Console.WriteLine("\nОчередь пустая!");
                return;
            }
            foreach (Person p in q)
            {
                sum += p.Age;
            }
            Console.WriteLine($"\nСредний возраст людей в очереди: {sum / q.Count}");
        }
        public static void Ages(Dictionary<string, Person> d)
        {
            uint sum = 0;
            if (d.Count == 0)
            {
                Console.WriteLine("\nСловарь пустой!");
                return;
            }
            foreach (KeyValuePair<string, Person> keyValue in d)
            {
                sum += keyValue.Value.Age;
            }
            Console.WriteLine($"\nСредний возраст людей в словаре: {sum / d.Count}");
        }
        public static void Employees(Queue q)
        {
            int counter = 0;
            foreach (Person p in q)
            {
                if (p is Employee)
                {
                    Employee e = p as Employee;
                    if (e.Salary > 100)
                    {
                        Console.WriteLine($"\n{counter + 1} такой работник: ");
                        e.Write();
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("\nТаких элементов нет!");
            }
        }
        public static void Employees(Dictionary<string, Person> d)
        {
            int counter = 0;
            foreach (KeyValuePair<string, Person> keyValue in d)
            {
                if (keyValue.Value is Employee)
                {
                    Employee e = keyValue.Value as Employee;
                    if (e.Salary > 100)
                    {
                        Console.WriteLine($"\n{counter + 1} такой работник: ");
                        e.Write();
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("\nТаких элементов нет!");
            }
        }
        public static void Teachers(Queue q)
        {
            int counter = 0;
            foreach (Person p in q)
            {
                if (p is Teacher)
                {
                    Teacher t = p as Teacher;
                    if (t.KolStud > 100)
                    {
                        Console.WriteLine($"\n{counter + 1} такой учитель: ");
                        t.Write();
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("\nТаких элементов нет!");
            }
        }
        public static void Teachers(Dictionary<string, Person> d)
        {
            int counter = 0;
            foreach (KeyValuePair<string, Person> keyValue in d)
            {
                if (keyValue.Value is Teacher)
                {
                    Teacher t = keyValue.Value as Teacher;
                    if (t.KolStud > 100)
                    {
                        Console.WriteLine($"\n{counter + 1} такой учитель: ");
                        t.Write();
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("\nТаких элементов нет!");
            }
        }
        static public void ProvDouble(out double a)
        {
            double n;
            bool ok;
            a = 0;
            do
            {
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out n);
                if (ok && n != 0) a = n;
                else Console.WriteLine("Введите, пожалуйста, положительное число!");
            } while (!ok || n == 0);
        }
        static public void ProvUint(out uint a)
        {
            uint n;
            bool ok;
            a = 0;
            do
            {
                string buf = Console.ReadLine();
                ok = uint.TryParse(buf, out n);
                if (ok && n != 0) a = n;
                else Console.WriteLine("Введите, пожалуйста, натуральное число!");
            } while (!ok || n == 0);
        }
        public static void Dobavlenie(ref Queue q)
        {
            int men = 0;
            Console.WriteLine("\n1. Создать преподавателя");
            Console.WriteLine("2. Создать студента");
            Console.WriteLine("3. Создать сотрудника");
            Console.WriteLine("4. Создать просто человека");
            Console.WriteLine("5. Создать животное (вне иерархии классов)");
            ProvMenu(ref men, 0, 6);
            switch (men)
            {
                case 1:
                    Console.WriteLine("\nЕго имя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint age);
                    Console.WriteLine("Его преподаваемый предмет: ");
                    string discipline = Console.ReadLine();
                    Console.WriteLine("Количество его студентов: ");
                    ProvUint(out uint stud);
                    Teacher t = new Teacher(name: name, surname: surname, age: age, discipline: discipline, kolStud: stud);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    q.Enqueue(t);
                    break;
                case 2:
                    Console.WriteLine("\nЕго имя: ");
                    string namest = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surnamest = Console.ReadLine();
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint agest);
                    Console.WriteLine("Его курс: ");
                    ProvUint(out uint course);
                    Console.WriteLine("Его средняя оценка: ");
                    ProvDouble(out double mark);
                    Student s = new Student(name: namest, surname: surnamest, age: agest, course: course, avmark: mark);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    q.Enqueue(s);
                    break;
                case 3:
                    Console.WriteLine("\nЕго имя: ");
                    string namesot = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surnamesot = Console.ReadLine();
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint agesot);
                    Console.WriteLine("Его зарплата: ");
                    ProvUint(out uint salary);
                    Console.WriteLine("Сколько лет он работает?");
                    ProvUint(out uint years);
                    Employee e = new Employee(name: namesot, surname: surnamesot, age: agesot, salary: salary, years: years);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    q.Enqueue(e);
                    break;
                case 4:
                    Console.WriteLine("\nЕго имя: ");
                    string nameper = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surnameper = Console.ReadLine();
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint ageper);
                    Person p = new Person(name: nameper, surname: surnameper, age: ageper);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    q.Enqueue(p);
                    break;
                case 5:
                    Console.WriteLine("\nЕго название: ");
                    string namean = Console.ReadLine();
                    Console.WriteLine("Его цвет: ");
                    string color = Console.ReadLine();
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint agean);
                    Animal an = new Animal(namean, color, agean, Number.count);
                    q.Enqueue(an);
                    Console.WriteLine("\nЖивотное создано!\n");
                    break;
            }
        }
        public static void Dobavlenie(ref Dictionary<string, Person> d, ref int Index)
        {
            int men = 0;
            Console.WriteLine("\n1. Создать преподавателя");
            Console.WriteLine("2. Создать студента");
            Console.WriteLine("3. Создать сотрудника");
            Console.WriteLine("4. Создать просто человека");
            ProvMenu(ref men, 0, 5);
            switch (men)
            {
                case 1:
                    Console.WriteLine("\nЕго имя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surname = Console.ReadLine();
                    if (d.ContainsKey(surname))
                    {
                        Console.WriteLine("\nЧеловек с такой фамилией уже создан! Мы добавим к фамилии индекс\n");
                        surname += Index.ToString();
                        Index++;
                    }
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint age);
                    Console.WriteLine("Его преподаваемый предмет: ");
                    string discipline = Console.ReadLine();
                    Console.WriteLine("Количество его студентов: ");
                    ProvUint(out uint stud);
                    Teacher t = new Teacher(name: name, surname: surname, age: age, discipline: discipline, kolStud: stud);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    d.Add(t.Surname, t);
                    break;
                case 2:
                    Console.WriteLine("\nЕго имя: ");
                    string namest = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surnamest = Console.ReadLine();
                    if (d.ContainsKey(surnamest))
                    {
                        Console.WriteLine("\nЧеловек с такой фамилией уже создан! Мы добавим к фамилии индекс");
                        surnamest += Index.ToString();
                        Index++;
                    }
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint agest);
                    Console.WriteLine("Его курс: ");
                    ProvUint(out uint course);
                    Console.WriteLine("Его средняя оценка: ");
                    ProvDouble(out double mark);
                    Student s = new Student(name: namest, surname: surnamest, age: agest, course: course, avmark: mark);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    d.Add(s.Surname, s);
                    break;
                case 3:
                    Console.WriteLine("\nЕго имя: ");
                    string namesot = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surnamesot = Console.ReadLine();
                    if (d.ContainsKey(surnamesot))
                    {
                        Console.WriteLine("\nЧеловек с такой фамилией уже создан! Мы добавим к фамилии индекс");
                        surnamesot += Index.ToString();
                        Index++;
                    }
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint agesot);
                    Console.WriteLine("Его зарплата: ");
                    ProvUint(out uint salary);
                    Console.WriteLine("Сколько лет он работает?");
                    ProvUint(out uint years);
                    Employee e = new Employee(name: namesot, surname: surnamesot, age: agesot, salary: salary, years: years);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    d.Add(e.Surname, e);
                    break;
                case 4:
                    Console.WriteLine("\nЕго имя: ");
                    string nameper = Console.ReadLine();
                    Console.WriteLine("Его фамилия: ");
                    string surnameper = Console.ReadLine();
                    if (d.ContainsKey(surnameper))
                    {
                        Console.WriteLine("\nЧеловек с такой фамилией уже создан! Мы добавим к фамилии индекс");
                        surnameper += Index.ToString();
                        Index++;
                    }
                    Console.WriteLine("Его возраст: ");
                    ProvUint(out uint ageper);
                    Person p = new Person(name: nameper, surname: surnameper, age: ageper);
                    Console.WriteLine($"\nЧеловек №{Person.count} создан\n");
                    d.Add(p.Surname, p);
                    break;
            }
        }
        public static void Delete(ref Queue q)
        {
            if (q.Count == 0)
            {
                Console.WriteLine("\nУдалять нечего!");
                return;
            }
            Person p = (Person)q.Dequeue();
            Console.WriteLine("\nУдаленный элемент: ");
            p.Write();
            if (q.Count == 0)
            {
                Console.WriteLine("\nОчередь опустела!");
                return;
            }
            Console.WriteLine("\nОставшаяся очередь:");
            foreach (Person per in q)
            {
                per.Write();
                Console.WriteLine();
            }
        }
        public static void Delete(ref Dictionary<string, Person> d)
        {
            if (d.Count == 0)
            {
                Console.WriteLine("\nУдалять нечего!");
                return;
            }
            Console.WriteLine("\nВведите фамилию человека, которого надо удалить\n");
            string buf = Console.ReadLine();
            Person a;
            if (d.ContainsKey(buf) == true)
            {
                a = d[buf];
                d.Remove(buf);
            }
            else
            {
                Console.WriteLine("\nТакого человека в словаре нет!\n");
                return;
            }
            Console.WriteLine("\nУдаленный элемент: ");
            a.Write();
            if (d.Count == 0)
            {
                Console.WriteLine("\nСловарь опустел!");
                return;
            }
        }
        public static void ProvMenu(ref int switchcase, int niz, int verh)
        {
            int n;
            bool ok;
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n);
                if (ok && n > niz && n < verh) switchcase = n;
                else Console.WriteLine("Выберите, пожалуйста, один из пунктов меню!");
            } while (!ok || n < (niz + 1) || n > (verh - 1));
        }
        public static void StartFirst(ref Queue q)
        {
            int switchcase = 0;
            do
            {
                Console.WriteLine("\nЧто вы хотите сделать?");
                Console.WriteLine("1. Добавить элемент в очередь");
                Console.WriteLine("2. Удалить элемент из очереди");
                Console.WriteLine("3. Найти учителей, у которых больше 100 учеников");
                Console.WriteLine("4. Определить, есть ли работники с опытом больше 5 лет");
                Console.WriteLine("5. Средний возраст всех созданных людей");
                Console.WriteLine("6. Выполнить клонирование коллекции");
                Console.WriteLine("7. Сортировка очереди с поиском элемента (сортировка и поиск по фамилии)");
                Console.WriteLine("8. Вывод очереди на экран");
                Console.WriteLine("9. Конец работы");
                ProvMenu(ref switchcase, 0, 10);
                switch (switchcase)
                {
                    case 1:
                        int Case1 = 0;
                        Console.WriteLine("1. Создать вручную");
                        Console.WriteLine("2. Создать автоматически");
                        ProvMenu(ref Case1, 0, 3);
                        if (Case1 == 1) Dobavlenie(ref q);
                        else RandomSozdanie(ref q);
                        break;
                    case 2:
                        Delete(ref q);
                        break;
                    case 3:
                        Teachers(q);
                        break;
                    case 4:
                        Employees(q);
                        break;
                    case 5:
                        Ages(q);
                        break;
                    case 6:
                        Clonirovanie(q);
                        break;
                    case 7:
                        Sort(ref q);
                        Poisk(q);
                        break;
                    case 8:
                        if (q.Count != 0) foreach (Person p in q) p.Write();
                        else Console.WriteLine("\nОчередь пустая!\n");
                        break;
                }
            } while (switchcase != 9);
        }
        public static void StartFirst(ref Dictionary<string, Person> d, ref int Index)
        {
            int switchcase = 0;
            do
            {
                Console.WriteLine("\nЧто вы хотите сделать?");
                Console.WriteLine("1. Добавить пару в cловарь");
                Console.WriteLine("2. Удалить пару из словаря");
                Console.WriteLine("3. Найти учителей, у которых больше 100 учеников");
                Console.WriteLine("4. Определить, есть ли работники с опытом больше 5 лет");
                Console.WriteLine("5. Средний возраст всех созданных людей");
                Console.WriteLine("6. Выполнить клонирование словаря");
                Console.WriteLine("7. Сортировка словаря с поиском элемента (сортировка и поиск по фамилии)");
                Console.WriteLine("8. Вывод словаря на экран");
                Console.WriteLine("9. Конец работы");
                ProvMenu(ref switchcase, 0, 10);
                switch (switchcase)
                {
                    case 1:
                        int Case1 = 0;
                        Console.WriteLine("1. Создать вручную");
                        Console.WriteLine("2. Создать автоматически");
                        ProvMenu(ref Case1, 0, 3);
                        if (Case1 == 1) Dobavlenie(ref d, ref Index);
                        else RandomSozdanie(ref d, ref Index);
                        break;
                    case 2:
                        Delete(ref d);
                        break;
                    case 3:
                        Teachers(d);
                        break;
                    case 4:
                        Employees(d);
                        break;
                    case 5:
                        Ages(d);
                        break;
                    case 6:
                        Clonirovanie(d);
                        break;
                    case 7:
                        if (d.Count == 0)
                        {
                            Console.WriteLine("\nСловарь пустой!\n");
                            break;
                        }
                        Sort(ref d);
                        Poisk(d);
                        break;
                    case 8:
                        if (d.Count != 0)
                        {
                            foreach (KeyValuePair<string, Person> keyValue in d)
                            {
                                Console.WriteLine($"\nФамилия человека:\n{keyValue.Key}\n\nЕго данные:");
                                keyValue.Value.Write();
                                Console.WriteLine("\n");
                            }
                        }
                        else Console.WriteLine("\nСловарь пустой!\n");
                        break;
                }
            } while (switchcase != 9);
        }
        public static void Sozdanie(ref Collections col)
        {
            Console.WriteLine("\nИмя студента: ");
            string namest = Console.ReadLine();
            Console.WriteLine("Фамилия студента: ");
            string surnamest = Console.ReadLine();
            Console.WriteLine("Возраст студента: ");
            ProvUint(out uint agest);
            Console.WriteLine("Его курс: ");
            ProvUint(out uint course);
            Console.WriteLine("Его средняя оценка: ");
            ProvDouble(out double mark);
            Student s = new Student(name: namest, surname: surnamest, age: agest, course: course, avmark: mark);
            Person.count--;
            Console.WriteLine($"\nКоллекции пополнены!\n");
            Person p = new Person(name: s.Name, surname: s.Surname, age: s.Age);
            if (col.first.Contains(p))
            {
                Console.WriteLine("\nТакой студент уже был ключом, поэтому мы проиндексируем его имя\n");
                p.Name += Collections.count.ToString();
                Collections.count++;
            }
            col.first.Add(p);
            col.second.Add(p.ToString());
            col.third.Add(p, s);
            col.forth.Add(p.ToString(), s);
        }
        static public void StartThird()
        {
            Console.WriteLine("\nКоллекции автоматически созданы!\n");
            Collections col = new Collections();
            int switchCase3 = 0;
            do
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1. Добавить по элементу в коллекции");
                Console.WriteLine("2. Удалить по элементу из коллекций");
                Console.WriteLine("3. Сравнить коллекции");
                Console.WriteLine("4. Закончить работу\n");
                ProvMenu(ref switchCase3, 0, 5);
                switch (switchCase3)
                {
                    case 1:
                        int swithCase31 = 0;
                        Console.WriteLine("\nКак вы хотите создать элементы?\n");
                        Console.WriteLine("1. Создать вручную");
                        Console.WriteLine("2. Создать автоматически");
                        ProvMenu(ref swithCase31, 0, 3);
                        switch (swithCase31)
                        {
                            case 1:
                                Sozdanie(ref col);
                                break;
                            case 2:
                                Student s = new Student();
                                s = (Student)s.Init();
                                Person per = new Person(name: s.Name, surname: s.Surname, age: s.Age);
                                Person.count = -2;
                                if (col.first.Contains(per))
                                {
                                    per.Name += Collections.count.ToString();
                                    Collections.count++;
                                }
                                col.first.Add(per);
                                col.second.Add(per.ToString());
                                col.third.Add(per, s);
                                col.forth.Add(per.ToString(), s);
                                Console.WriteLine("\nКоллекции пополнены!\n");
                                break;
                        }
                        break;
                    case 2:
                        if (col.first.Count == 0)
                        {
                            Console.WriteLine("\nКоллекции и так пустые!\n");
                            break;
                        }
                        Person p = new Person(col.first[col.first.Count - 1].Name, col.first[col.first.Count - 1].Surname, col.first[col.first.Count - 1].Age);
                        Console.WriteLine("\nУдаленный элемент:");
                        p.Write();
                        col.first.RemoveAt(col.first.Count - 1);
                        col.second.RemoveAt(col.first.Count - 1);
                        col.third.Remove(p);
                        col.forth.Remove(p.ToString());
                        Console.WriteLine("\nКоллекции изменены!\n");
                        break;
                    case 3:
                        if (col.first.Count == 0)
                        {
                            Console.WriteLine("\nВсе коллекции пустые!\n");
                            break;
                        }
                        //
                        Stopwatch FirstCollectionOne = new Stopwatch();
                        Person PerFirstOne = new Person(col.first[0].Name, col.first[0].Surname, col.first[0].Age);
                        FirstCollectionOne.Start();
                        col.first.Contains(PerFirstOne);
                        FirstCollectionOne.Stop();
                        Console.WriteLine(col.first.Contains(PerFirstOne));
                        Console.WriteLine(FirstCollectionOne.ElapsedTicks);
                        Console.WriteLine("Первая, первый");
                        Console.WriteLine();

                        Stopwatch FirstCollectionMiddle = new Stopwatch();
                        Person PerMiddleOne = new Person(col.first[500].Name, col.first[500].Surname, col.first[500].Age);
                        FirstCollectionMiddle.Start();
                        col.first.Contains(PerMiddleOne);
                        FirstCollectionMiddle.Stop();
                        Console.WriteLine(col.first.Contains(PerMiddleOne));
                        Console.WriteLine(FirstCollectionMiddle.ElapsedTicks);
                        Console.WriteLine("Первая, средний");
                        Console.WriteLine();

                        Stopwatch FirstCollectionLast = new Stopwatch();
                        Person PerLastOne = new Person(col.first[999].Name, col.first[999].Surname, col.first[999].Age);
                        FirstCollectionLast.Start();
                        col.first.Contains(PerLastOne);
                        FirstCollectionLast.Stop();
                        Console.WriteLine(col.first.Contains(PerLastOne));
                        Console.WriteLine(FirstCollectionLast.ElapsedTicks);
                        Console.WriteLine("Первая, последний");
                        Console.WriteLine();

                        Stopwatch FirstCollectionNone = new Stopwatch();
                        Person PerNoneOne = new Person(name: "Nikolai", surname: "Burnyshev", age: 18);
                        FirstCollectionNone.Start();
                        col.first.Contains(PerNoneOne);
                        FirstCollectionNone.Stop();
                        Console.WriteLine(col.first.Contains(PerNoneOne));
                        Console.WriteLine(FirstCollectionNone.ElapsedTicks);
                        Console.WriteLine("Первая, никакой");
                        Console.WriteLine();

                        //

                        Stopwatch SecondCollectionOne = new Stopwatch();
                        string FirstOne = col.second[0];
                        SecondCollectionOne.Start();
                        col.second.Contains(FirstOne);
                        SecondCollectionOne.Stop();
                        Console.WriteLine(col.second.Contains(FirstOne));
                        Console.WriteLine(SecondCollectionOne.ElapsedTicks);
                        Console.WriteLine("Вторая, первый");
                        Console.WriteLine();

                        Stopwatch SecondCollectionMiddle = new Stopwatch();
                        string MiddleOne = col.second[500];
                        SecondCollectionMiddle.Start();
                        col.second.Contains(MiddleOne);
                        SecondCollectionMiddle.Stop();
                        Console.WriteLine(col.second.Contains(MiddleOne));
                        Console.WriteLine(SecondCollectionMiddle.ElapsedTicks);
                        Console.WriteLine("Вторая, средний");
                        Console.WriteLine();

                        Stopwatch SecondCollectionLast = new Stopwatch();
                        string LastOne = col.second[999];
                        SecondCollectionLast.Start();
                        col.second.Contains(LastOne);
                        SecondCollectionLast.Stop();
                        Console.WriteLine(col.second.Contains(LastOne));
                        Console.WriteLine(SecondCollectionLast.ElapsedTicks);
                        Console.WriteLine("Вторая, последний");
                        Console.WriteLine();

                        Stopwatch SecondCollectionNone = new Stopwatch();
                        string NoneOne = "ABCDEF";
                        SecondCollectionNone.Start();
                        col.second.Contains(NoneOne);
                        SecondCollectionNone.Stop();
                        Console.WriteLine(col.second.Contains(NoneOne));
                        Console.WriteLine(SecondCollectionNone.ElapsedTicks);
                        Console.WriteLine("Вторая, никакой");
                        Console.WriteLine();

                        //

                        Stopwatch ThirdCollectionOne = new Stopwatch();
                        List<Person> a = new List<Person>(col.third.Keys);
                        Person PerFirstThird = new Person(name: a[0].Name, surname: a[0].Surname, age: a[0].Age);
                        ThirdCollectionOne.Start();
                        col.third.ContainsKey(PerFirstThird);
                        ThirdCollectionOne.Stop();
                        Console.WriteLine(col.third.ContainsKey(PerFirstThird));
                        Console.WriteLine(ThirdCollectionOne.ElapsedTicks);
                        Console.WriteLine("Третья, первый");
                        Console.WriteLine();

                        Stopwatch ThirdCollectionMiddle = new Stopwatch();
                        Person PerMiddleThird = new Person(name: a[500].Name, surname: a[500].Surname, age: a[500].Age);
                        ThirdCollectionMiddle.Start();
                        col.third.ContainsKey(PerMiddleThird);
                        ThirdCollectionMiddle.Stop();
                        Console.WriteLine(col.third.ContainsKey(PerMiddleThird));
                        Console.WriteLine(ThirdCollectionMiddle.ElapsedTicks);
                        Console.WriteLine("Третья, средний");
                        Console.WriteLine();

                        Stopwatch ThirdCollectionLast = new Stopwatch();
                        Person PerLastThird = new Person(name: a[999].Name, surname: a[999].Surname, age: a[999].Age);
                        ThirdCollectionLast.Start();
                        col.third.ContainsKey(PerLastThird);
                        ThirdCollectionLast.Stop();
                        Console.WriteLine(col.third.ContainsKey(PerLastThird));
                        Console.WriteLine(ThirdCollectionLast.ElapsedTicks);
                        Console.WriteLine("Третья, последний");
                        Console.WriteLine();

                        Stopwatch ThirdCollectionNone = new Stopwatch();
                        Person PerNoneThird = new Person(name: "Nikolai", surname: "Burnyshev", age: 18);
                        ThirdCollectionNone.Start();
                        col.third.ContainsKey(PerNoneThird);
                        ThirdCollectionNone.Stop();
                        Console.WriteLine(col.third.ContainsKey(PerNoneThird));
                        Console.WriteLine(ThirdCollectionNone.ElapsedTicks);
                        Console.WriteLine("Третья, никакой");
                        Console.WriteLine();

                        //

                        Stopwatch ForthCollectionOne = new Stopwatch();
                        List<string> b = new List<string>(col.forth.Keys);
                        string ForthOne = b[0];
                        ForthCollectionOne.Start();
                        col.forth.ContainsKey(ForthOne);
                        ForthCollectionOne.Stop();
                        Console.WriteLine(col.forth.ContainsKey(ForthOne));
                        Console.WriteLine(ForthCollectionOne.ElapsedTicks);
                        Console.WriteLine("Четвёртая, первый");
                        Console.WriteLine();

                        Stopwatch ForthCollectionMiddle = new Stopwatch();
                        string ForthMiddle = b[500];
                        ForthCollectionMiddle.Start();
                        col.forth.ContainsKey(ForthMiddle);
                        ForthCollectionMiddle.Stop();
                        Console.WriteLine(col.forth.ContainsKey(ForthMiddle));
                        Console.WriteLine(ForthCollectionMiddle.ElapsedTicks);
                        Console.WriteLine("Четвёртая, средний");
                        Console.WriteLine();

                        Stopwatch ForthCollectionLast = new Stopwatch();
                        string ForthLast = b[999];
                        ForthCollectionLast.Start();
                        col.forth.ContainsKey(ForthLast);
                        ForthCollectionLast.Stop();
                        Console.WriteLine(col.forth.ContainsKey(ForthLast));
                        Console.WriteLine(ForthCollectionLast.ElapsedTicks);
                        Console.WriteLine("Четвёртая, последний");
                        Console.WriteLine();

                        Stopwatch ForthCollectionNone = new Stopwatch();
                        string ForthNone = "ABCDEF";
                        ForthCollectionNone.Start();
                        col.forth.ContainsKey(ForthNone);
                        ForthCollectionNone.Stop();
                        Console.WriteLine(col.forth.ContainsKey(ForthNone));
                        Console.WriteLine(ForthCollectionNone.ElapsedTicks);
                        Console.WriteLine("Четвёртая, никакой");
                        Console.WriteLine();

                        //

                        Stopwatch FifthCollectionOne = new Stopwatch();
                        List<Student> st = new List<Student>(col.third.Values);
                        Student StFirstFifth = new Student(name: st[0].Name, surname: st[0].Surname, age: st[0].Age, course: st[0].Course, avmark: st[0].AvMark);
                        FifthCollectionOne.Start();
                        col.third.ContainsValue(StFirstFifth);
                        FifthCollectionOne.Stop();
                        Console.WriteLine(col.third.ContainsValue(StFirstFifth));
                        Console.WriteLine(FifthCollectionOne.ElapsedTicks);
                        Console.WriteLine("Пятая, первый");
                        Console.WriteLine();

                        Stopwatch FifthCollectionMiddle = new Stopwatch();
                        Student StMiddleFifth = new Student(name: st[500].Name, surname: st[500].Surname, age: st[500].Age, course: st[500].Course, avmark: st[500].AvMark);
                        FifthCollectionMiddle.Start();
                        col.third.ContainsValue(StMiddleFifth);
                        FifthCollectionMiddle.Stop();
                        Console.WriteLine(col.third.ContainsValue(StMiddleFifth));
                        Console.WriteLine(FifthCollectionMiddle.ElapsedTicks);
                        Console.WriteLine("Пятая, средний");
                        Console.WriteLine();

                        Stopwatch FifthCollectionLast = new Stopwatch();
                        Student StLastFifth = new Student(name: st[999].Name, surname: st[999].Surname, age: st[999].Age, course: st[999].Course, avmark: st[999].AvMark);
                        FifthCollectionLast.Start();
                        col.third.ContainsValue(StLastFifth);
                        FifthCollectionLast.Stop();
                        Console.WriteLine(col.third.ContainsValue(StLastFifth));
                        Console.WriteLine(FifthCollectionLast.ElapsedTicks);
                        Console.WriteLine("Пятая, последний");
                        Console.WriteLine();


                        Stopwatch FifthCollectionNone = new Stopwatch();
                        Student StNoneFifth = new Student(name: "Burnyshev", surname: "Nikolai", age: 18, course: 1, avmark: 10);
                        FifthCollectionNone.Start();
                        col.third.ContainsValue(StNoneFifth);
                        FifthCollectionNone.Stop();
                        Console.WriteLine(col.third.ContainsValue(StNoneFifth));
                        Console.WriteLine(FifthCollectionNone.ElapsedTicks);
                        Console.WriteLine("Пятая, никакой");
                        Console.WriteLine();

                        //

                        Console.WriteLine("Позиция элемента:\tПервый в коллекции\tВ середине\tВ конце\t\tНе в коллекции");
                        Console.WriteLine("\nВид коллекции:\n");
                        Console.WriteLine($"Список Person\t\t    {FirstCollectionOne.ElapsedTicks}\t\t           {FirstCollectionMiddle.ElapsedTicks}\t\t  {FirstCollectionLast.ElapsedTicks}\t\t   {FirstCollectionNone.ElapsedTicks}  -  Метод Contains");
                        if (SecondCollectionOne.ElapsedTicks > 999) Console.WriteLine($"\nСписок cтрок\t\t    {SecondCollectionOne.ElapsedTicks}\t           {SecondCollectionMiddle.ElapsedTicks}\t\t  {SecondCollectionLast.ElapsedTicks}\t\t   {SecondCollectionNone.ElapsedTicks}  -  Метод Contains");
                        else Console.WriteLine($"\nСписок cтрок\t\t    {SecondCollectionOne.ElapsedTicks}\t\t           {SecondCollectionMiddle.ElapsedTicks}\t          {SecondCollectionLast.ElapsedTicks}\t\t   {SecondCollectionNone.ElapsedTicks}  -  Метод Contains");
                        Console.WriteLine($"\nСловарь Person\t\t    {ThirdCollectionOne.ElapsedTicks}\t\t           {ThirdCollectionMiddle.ElapsedTicks}\t\t  {ThirdCollectionLast.ElapsedTicks}\t\t   {ThirdCollectionNone.ElapsedTicks}  -  Метод ContainsKey");
                        Console.WriteLine($"\nСловарь строк\t\t    {ForthCollectionOne.ElapsedTicks}\t\t           {ForthCollectionMiddle.ElapsedTicks}\t\t  {ForthCollectionLast.ElapsedTicks}\t\t   {ForthCollectionNone.ElapsedTicks}  -  Метод ContainsKey");
                        Console.WriteLine($"\nСловарь Person\t\t    {FifthCollectionOne.ElapsedTicks}\t\t   {FifthCollectionMiddle.ElapsedTicks}\t\t {FifthCollectionLast.ElapsedTicks}\t\t   {FifthCollectionNone.ElapsedTicks}  -  Метод ContainsValue\n\n");
                        break;
                }
            } while (switchCase3 != 3 || switchCase3 != 4);
        }
        static void Main(string[] args)
        {
            int switchCase = 0;
            do
            {
                int Index = 0;
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1. Работать с коллекцией");
                Console.WriteLine("2. Работать с обобщенной коллекцией");
                Console.WriteLine("3. Сравнить коллекции");
                Console.WriteLine("4. Закончить работу");
                ProvMenu(ref switchCase, 0, 5);
                switch (switchCase)
                {
                    case 1:
                        Queue q = new Queue();
                        StartFirst(ref q);
                        break;
                    case 2:
                        Dictionary<string, Person> d = new Dictionary<string, Person>();
                        StartFirst(ref d, ref Index);
                        break;
                    case 3:
                        StartThird();
                        break;
                }
            } while (switchCase != 4);
        }
    }
}