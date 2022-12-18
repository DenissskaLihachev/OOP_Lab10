using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Класс Car должен иметь свойства Year (год изготовления) и Company(название компаниипроизводителя).
//Метод Show() должен выводить в консоль только название и компанию-производитель данного автомобиля.

//         Кроме массива метод получает значение «минимальный год выпуска автомобиля». Метод
//    находит в массиве все объекты типа Car, у которых год выпуска больше или равен
//    минимальному(выражение when). Выводит данные автомобиля с помощью метода
//    Show(), а также год выпуска, полученный через переменную паттерна свойств.

namespace ConsoleApp12.Class
{
    public class Car : Transport
    {
        public Car()
        {
            Name = "Undefined";
            Year = 0;
            Company = "Undefined";
        }
        public Car(string name, int year, string company)
        {
            Name = name;
            Year = year;
            Company = company;
        }

        public int Year { get; set; }
        public string Company { get; set; }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Название - [{Name}] | Компания-производитель - [{Company}]");
            Console.ResetColor();
        }
    }
}