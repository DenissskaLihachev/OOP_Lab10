using ConsoleApp12.Class;
using System.Diagnostics;

namespace Lab9_OOP
{
//    Создайте массив объектов Transport и заполните его объектами Car и Aircraft(можно их
//  случайно сгенерировать).
//    Напишите и протестируйте на данном массиве два метода с использованием паттерна типов
//  и паттерна свойств:
//         Кроме массива метод получает значение «минимальный год выпуска автомобиля». Метод
//    находит в массиве все объекты типа Car, у которых год выпуска больше или равен
//    минимальному(выражение when). Выводит данные автомобиля с помощью метода
//    Show(), а также год выпуска, полученный через переменную паттерна свойств.
//         Кроме массива метод получает значение «минимальной дистанции полета». Метод
//    находит в массиве все объекты типа Aircraft, у которых дистанция больше или равна
//    минимальной.При этом сперва выведите все пассажирские самолеты, а затем остальные
//    (используйте для этого паттерн свойств).

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1) Задание 1\n2) Задание 2\n3) Задание 3\nВвод: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            Task1();
                            break;
                        }
                    case 2:
                        {
                            Task2();
                            break;
                        }
                    case 3:
                        {
                            Task3();
                            break;
                        }
                }
            }

        }
        static void Task1()
        {
            void Method(int year, int distance, Transport[] transport)
            {
                for (int i = 0; i < transport.Length; i++)
                {
                    switch (transport[i])
                    {
                        case Car car when car.Year >= year:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("МАШИНА: ");
                            Console.ResetColor();
                            car.Show();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" Год выпуска - [{car.Year}]\n");
                            Console.ResetColor();
                            break;
                        case Aircraft aircraft when aircraft.Distance >= distance:
                            if (aircraft is Aircraft { Passenger: true })
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("САМОЛЕТ: ");
                                Console.ResetColor();
                                aircraft.Show();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($" Дистанция полета - [{aircraft.Distance}]\n");
                                Console.ResetColor();
                            }
                            break;
                    }
                }
                for (int i = 0; i < transport.Length; i++)
                {
                    switch (transport[i])
                    {
                        case Aircraft aircraft when aircraft.Distance >= distance:
                            if (aircraft is Aircraft { Passenger: false })
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("САМОЛЕТ: ");
                                Console.ResetColor();
                                aircraft.Show();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($" Дистанция полета - [{aircraft.Distance}]\n");
                                Console.ResetColor();
                            }
                            break;
                    }
                }
            }

            Transport[] transport = new Transport[4];
            transport[0] = new Car("Nissan Skyline", 1995, "TOYOTA");
            transport[1] = new Car("Toyota Sprinter", 1993, "NISSAN");
            transport[2] = new Aircraft("Sukhoi Superjet 100", true, 10000);
            transport[3] = new Aircraft("Су-57", false, 100000);

            Method(1994, 1000, transport);

            Console.ReadLine(); Console.Clear();
        }
        static void Task2()
        {
            AuthorizedData authorizeddata  = new AuthorizedData() { Login = "Login1", Access = AccessType.User,     Password = "password1" };
            AuthorizedData authorizeddata1 = new AuthorizedData() { Login = "Login2", Access = AccessType.Operator, Password = "password2" };
            AuthorizedData authorizeddata2 = new AuthorizedData() { Login = "Login3", Access = AccessType.Admin,    Password = "password3" };
            AuthorizedData authorizeddata3 = new AuthorizedData() {};

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("User: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Method(authorizeddata));
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Operator: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Method(authorizeddata1));
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Admin: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Method(authorizeddata2));
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Unknow Data: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Method(authorizeddata3));
            Console.ResetColor();


            string Method(AuthorizedData authorizedData) => authorizedData switch
            {
                (_, AccessType.User, _)              => "Hello User",
                ("Login2", AccessType.Operator, _)   => "Hello Operator",
                (_, AccessType.Admin, "password3")   => "Администратор " + authorizedData.Login + " авторизовался",
                _                                    => "Unknow data"
            };

            Console.ReadLine(); Console.Clear();
        }
        static void Task3()
        {
            EmployeeData employeeData   = new EmployeeData() { Name = "Директор", Status = Status.Director, Experience = 7 };
            EmployeeData employeeData1  = new EmployeeData() { Name = "Работник", Status = Status.Worker, Experience = 2 };
            employeeData.Show();
            employeeData1.Show();

            Console.ReadLine(); Console.Clear();
        }
    }
}