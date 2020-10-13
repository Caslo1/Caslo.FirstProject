using CasloFirstProjectPerson.Controller;
using CasloFirstProjectPerson.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CasloFirstProject.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("CasloFirstProject.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Welcom", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var expController = new ExpController(userController.CurrentUser);

            if(userController.IsNewUser)
            {
                Console.WriteLine("Создайте имя персонажа");
                var character = Console.ReadLine();

                Console.Write("Количество персонажей ");
                var quantity = ParseInt("Количество персонажей ");
                Console.Write("Уровень персонажа ");
                var lvl = ParseInt("Уровень персонажа ");


                userController.SetNewUserData(character, quantity, lvl);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Вы хотите добавить побеждённого противника? ");
            Console.WriteLine("Нажмите Y ");
            key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key == ConsoleKey.Y)
            {
                var unites = EnterUnits();
                expController.Add(unites.Units, unites.Exp);

                foreach(var item in expController.lvlUps.Unites)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Units Units, int Exp) EnterUnits()
        {
            Console.Write("Введите имя противника которого вы победили: ");
            var name = Console.ReadLine();

            Console.Write("Введите полученный опыт: ");
            var exp = ParseInt("Опыт полученный за противника ");
            var unit = new Units(name, exp);

            return (unit, exp);

        }

        private static int ParseInt(string name)
        {
            while(true)
            {
                Console.WriteLine($"Введите правильно {name}: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Введите правильный формат поля {name} ");
                }
            }
        }
    }
}
