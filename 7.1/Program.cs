using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class HelloWorld
{
    internal class Person
    {
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public DateTime Birthday { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private char gender;
        public char Gender
        {
            get { return gender; }
            set
            {
                if ((value == 'm') || (value == 'M') || (value == 'f') || (value == 'F'))
                    gender = value;
            }
        }
        public Person() { }
        public Person(string name, string surname, char gender)
        {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
        }
        public override string ToString()
        {
            return name + " " + surname + " " + gender;
        }
    }
    public static int GetAge(DateTime birthDate)
    {
        var now = DateTime.Today;
        return now.Year - birthDate.Year - 1 +
            ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
    }
    class Employee : Person
    {
        protected double zarplata;
        public double Zarplata
        {
            get { return zarplata; }
            set { zarplata = value; }
        }
        protected double premia;
        public double Premia
        {
            get { return premia; }
            set { premia = value; }
        }
        public Employee() { }
        public Employee(string name, string surname, char gender, double zp, double prem)
            : base(name, surname, gender)
        {
            zarplata = zp;
            premia = prem;
        }
        protected double fzp, nolog, postnolog;
        public virtual void FullZP()
        {
            fzp = zarplata + premia;
            Console.WriteLine("Зарплата с премией, полная зарплата: " + fzp);
        }
        public void Nalog()
        {
            nolog = fzp / 100 * 13;
            Console.WriteLine("Налог: " + nolog);
        }
        public void PosleNalog()
        {
            postnolog = fzp / 100 * 87;
            Console.WriteLine("После вычета налога: " + postnolog);
        }
    }
    class EmployeePerHour : Employee
    {
        protected double hours;
        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }
        public EmployeePerHour() { }
        public EmployeePerHour(string name, string surname, char gender, double zp, double prem, double chas)
            : base(name, surname, gender, zp, prem)
        {
            hours = chas;
        }
        public override void FullZP()
        {
            fzp = zarplata * hours + premia;
            Console.WriteLine("Заработано: " + zarplata * hours);
            Console.WriteLine("С премией: " + fzp);
        }
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Person[] X = new Person[n];
        for (int i = 0; i < n; i++)
        {
            char pol = ' ';
            Console.WriteLine("Имя");
            string imya = Console.ReadLine();
            Console.WriteLine("Фамилия");
            string familia = Console.ReadLine();
            Console.WriteLine("Пол");
            string str = Console.ReadLine();
            if ((str.Length == 1) && ((str[0] == 'm') || (str[0] == 'M') || (str[0] == 'f') || (str[0] == 'F')))
            { pol = str[0]; }
            else
            {
                pol = 'N';
                Console.WriteLine("Wrong letter. Changed to N");
            }
            Console.WriteLine("Год, месяц, день рождения");
            int y = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            X[i] = new Person(imya, familia, pol);
            X[i].Birthday = new DateTime(y, m, d);
        }
        Employee[] Y = new Employee[n];
        for (int i = 0; i < n; i++)
        {
            char pol = ' ';
            Console.WriteLine("Имя");
            string imya = Console.ReadLine();
            Console.WriteLine("Фамилия");
            string familia = Console.ReadLine();
            Console.WriteLine("Пол");
            string str = Console.ReadLine();
            if ((str.Length == 1) && ((str[0] == 'm') || (str[0] == 'M') || (str[0] == 'f') || (str[0] == 'F')))
            { pol = str[0]; }
            else
            {
                pol = 'N';
                Console.WriteLine("Wrong letter. Changed to N");
            }
            Console.WriteLine("Год, месяц, день рождения");
            int y = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Зарплата");
            double zarpl = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Премия");
            double prm = Convert.ToDouble(Console.ReadLine());
            Y[i] = new Employee(imya, familia, pol, zarpl, prm);
            Y[i].Birthday = new DateTime(y, m, d);
        }
        EmployeePerHour[] Z = new EmployeePerHour[n];
        for (int i = 0; i < n; i++)
        {
            char pol = ' ';
            Console.WriteLine("Имя");
            string imya = Console.ReadLine();
            Console.WriteLine("Фамилия");
            string familia = Console.ReadLine();
            Console.WriteLine("Пол");
            string str = Console.ReadLine();
            if ((str.Length == 1) && ((str[0] == 'm') || (str[0] == 'M') || (str[0] == 'f') || (str[0] == 'F')))
            { pol = str[0]; }
            else
            {
                pol = 'N';
                Console.WriteLine("Wrong letter. Changed to N");
            }
            Console.WriteLine("Год, месяц, день рождения");
            int y = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Оклад за час");
            double zarpl = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Премия");
            double prm = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Отработно часов");
            double hrs = Convert.ToDouble(Console.ReadLine());
            Z[i] = new EmployeePerHour(imya, familia, pol, zarpl, prm, hrs);
            Z[i].Birthday = new DateTime(y, m, d);
        }
        Console.WriteLine("Информация:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(X[i].Name + " " + X[i].Surname + " " + X[i].Gender);
            Console.WriteLine("Полных лет: " + GetAge(X[i].Birthday));
        }
        Console.WriteLine("Информация о работниках:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Y[i].Name + " " + Y[i].Surname + " " + Y[i].Gender);
            Console.WriteLine("Полных лет: " + GetAge(Y[i].Birthday));
            Y[i].FullZP();
            Y[i].Nalog();
            Y[i].PosleNalog();
        }
        Console.WriteLine("Информация о работниках почасовой оплаты:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Z[i].Name + " " + Z[i].Surname + " " + Z[i].Gender);
            Console.WriteLine("Полных лет: " + GetAge(Z[i].Birthday));
            Z[i].FullZP();
            Z[i].Nalog();
            Z[i].PosleNalog();
        }
    }
}