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
            var dungeonController = new DungeonController(userController.CurrentUser);

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


            while(true)
            {
                Console.WriteLine("Вы хотите добавить побеждённого противника? ");
                Console.WriteLine("Нажмите Y чтобы добавить побеждённого противника");
                Console.WriteLine("Нажмите D чтобы добавить пройденное подземелье");
                Console.WriteLine("Нажмите Q чтобы выйти");

                key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.Y:
                        var unites = EnterUnits();
                        expController.Add(unites.Units, unites.Exp);

                        foreach (var item in expController.lvlUps.Unites)
                        {
                            Console.WriteLine($"\t {item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.D:
                        var dung = EnterDungeon();

                        dungeonController.Add(dung.Play, dung.Begin, dung.End);

                        foreach(var item in dungeonController.Dungeons)
                        {
                            Console.WriteLine($"\t {item.Play} - {item.Start} - {item.Finish}");
                        }

                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }

        }

        private static (int Begin, int End, Play Play) EnterDungeon()
        {
            Console.Write("Введите подземелье: ");
            var name = Console.ReadLine();

            var quantityunits = ParseInt("Количество противников");
            var begin = ParseInt("Начало подземелья");
            var end = ParseInt("Конец подземелья");

            var play = new Play(name, quantityunits);

            return (begin, end, play);
        }

        private static (Units Units, int Exp) EnterUnits()
        {
            Console.Write("Введите имя противника которого вы победили: ");
            var name = Console.ReadLine();

            var exp = ParseInt("Опыт полученный за противника ");
            var unit = new Units(name, exp);

            return (unit, exp);

        }

        private static int ParseInt(string name)
        {
            while(true)
            {
                Console.WriteLine($"Введите {name}: ");
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
