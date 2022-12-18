using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.Class
{
    enum Status
    {
        Director,
        Worker
    }

    delegate int SalaryCalculate(Status status);
    delegate double Rate(int Experience);
    internal class EmployeeData
    {
        SalaryCalculate salarycalculate = SalaryCalcul;
        Rate rate = CalcRate;

        private int experience;
        public string? Name { get; set; }
        public Status Status { get; set; }
        public int Experience { get => experience; set => experience = value >= 0 ? value : 0; }
        public double Salary { get => salarycalculate(Status) * rate(experience); }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Имя - [");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Name);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] | Должность - [");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Status);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] | Опыт - [");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Experience);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] | Зарплата - [");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Salary);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("]\n");
            Console.ResetColor();

        }

        public static int SalaryCalcul(Status status) => status switch
        {
            (Status.Director) => 999999,
            (Status.Worker) => 99999,
            (_) => 0
        };

        public static double CalcRate(int exp)
        {
            return exp switch
            {
                < 3 => 1,
                >= 3 and < 5 => 1.1,
                >= 5 => 2
            };
        }
    }
}