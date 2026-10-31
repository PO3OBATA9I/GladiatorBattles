using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorBattles
{
    internal class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            double StartHealth1, Armor1, RandomDamage1, Damage1, EndHealth1;
            double StartHealth2, Armor2, Damage2, RandomDamage2, EndHealth2;
            double minDamage1 = 0, minDamage2 = 0, maxDamage1 = 0, maxDamage2 = 0;
            int weaponChoice1 = 0, weaponChoice2 = 0;
            string Text;

            //Цвет заднего фона и текста + заголовок
            Console.Title = "Бой двух гладиаторов";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            Console.WriteLine("=============== ПЕРВЫЙ БОЕЦ ===============");
            //Ввод начального уровня здоровья для ПЕРВОГО бойца
            Console.WriteLine("Введите начальный уровень здоровья у первого бойца: ");
            Text = Console.ReadLine();
            StartHealth1 = Convert.ToDouble(Text);

            //Ввод крепости брони в % для ПЕРВОГО бойца
            rep: Console.WriteLine("Введите крепость брони у первого бойца (в %): ");
            Text = Console.ReadLine();
            Armor1 = Convert.ToDouble(Text);

            //Проверка крепости брони 1
            if (Armor1 < 0 || Armor1 > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Крепость брони должна быть от 0 до 100 %");
                Console.ForegroundColor = ConsoleColor.Green;
                goto rep;
            }

            //Выбор оружия
            Console.WriteLine("==================== Выберите оружие для первого гладиатора ====================");
            Console.WriteLine("                                      1 - Меч");
            Console.WriteLine("                                      2 - Топор");
            Console.WriteLine("                                      3 - Копьё");

            while (weaponChoice1 == 0)
            {
                Console.WriteLine("Введите номер или название оружия: ");
                Text = Console.ReadLine();

                Text = Text.ToLower(); //Чтобы (например) Топор, топор и ТОПОР считались одинак.

                if (Text == "1" || Text == "меч")
                {
                    weaponChoice1 = 1;
                }
                else if (Text == "2" || Text == "топор")
                {
                    weaponChoice1 = 2;
                }
                else if (Text == "3" || Text == "копьё" || Text == "копье")
                {
                    weaponChoice1 = 3;
                }
                else
                //проверка ввода оружия               
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Введите 1, 2, 3 или название оружия (Меч, Топор, Копьё).");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            //выбираем диапазон урона для кажд. оружия ПЕРВОГО бойца
            switch (weaponChoice1)
            {
                case 1:
                    minDamage1 = 50.0;
                    maxDamage1 = 75.0;
                    Console.WriteLine("Выбран Меч.");
                    break;

                case 2:
                    minDamage1 = 40.0;
                    maxDamage1 = 65.0;
                    Console.WriteLine("Выбран Топор.");
                    break;

                case 3:
                    minDamage1 = 30.0;
                    maxDamage1 = 55.0;
                    Console.WriteLine("Выбрано Копьё.");
                    break;
            }





            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=============== ВТОРОЙ БОЕЦ ===============");

            //Ввод здоровья и % брони для ВТОРОГО бойца
            Console.WriteLine("Введите начальный уровень здоровья у второго бойца: ");
            Text = Console.ReadLine();
            StartHealth2 = Convert.ToDouble(Text);

            rep1: Console.WriteLine("Введите крепость брони у второго бойца (в %): ");
            Text = Console.ReadLine();
            Armor2 = Convert.ToDouble(Text);


            //Проверка крепости брони 2
            if (Armor2 < 0 || Armor2 > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Крепость брони должна быть от 0 до 100 %");
                Console.ForegroundColor = ConsoleColor.Green;
                goto rep1;
            }

            Console.WriteLine("==================== Выберите оружие для второго гладиатора ====================");
            Console.WriteLine("                                      1 - Меч");
            Console.WriteLine("                                      2 - Топор");
            Console.WriteLine("                                      3 - Копьё");

                while (weaponChoice2 == 0)
                {
                    Console.WriteLine("Введите номер или название оружия: ");
                    Text = Console.ReadLine();

                    Text = Text.ToLower(); //Чтобы (например) Топор, топор и ТОПОР считались одинак.

                    if (Text == "1" || Text == "меч")
                    {
                        weaponChoice2 = 1;
                    }
                    else if (Text == "2" || Text == "топор")
                    {
                        weaponChoice2 = 2;
                    }
                    else if (Text == "3" || Text == "копьё" || Text == "копье")
                    {
                        weaponChoice2 = 3;
                    }
                    else
                    //проверка ввода оружия               
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Введите 1, 2, 3 или название оружия (Меч, Топор, Копьё).");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                    //выбираем диапазон урона для кажд. оружия ВТОРОГО бойца
                    switch (weaponChoice2)
            {
                case 1:
                    minDamage2 = 50.0;
                    maxDamage2 = 75.0;
                    Console.WriteLine("Выбран Меч.");
                    break;

                case 2:
                    minDamage2 = 40.0;
                    maxDamage2 = 65.0;
                    Console.WriteLine("Выбран Топор.");
                    break;

                case 3:
                    minDamage2 = 30.5;
                    maxDamage2 = 55.0;
                    Console.WriteLine("Выбрано Копьё.");
                    break;
            }






            Console.ForegroundColor = ConsoleColor.Black;
            EndHealth1 = StartHealth1;
            EndHealth2 = StartHealth2;
            int CountHit = 0;

            for (; EndHealth1 > 0 && EndHealth2 > 0; ) 
            {
                //Удар ПЕРВОГО бойца по ВТОРОМУ
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Удар номер {CountHit+1}"); //Пишет номер удара

                Console.ForegroundColor = ConsoleColor.Black;
                RandomDamage1 = minDamage1 + rand.NextDouble() * (maxDamage1 - minDamage1);
                Console.WriteLine("===============================================");
                Console.WriteLine($"Первый боец наносит удар силой: {RandomDamage1:F1}");

                //Урон с учётом брони ВТОРОГО бойца
                Damage1 = RandomDamage1 - (RandomDamage1 * Armor2 / 100);
                Console.WriteLine($"Итоговый урон по второму бойцу (с учётом брони): {Damage1:F1}");

                EndHealth2 -= Damage1;
                if (EndHealth2 < 0) EndHealth2 = 0;
                Console.WriteLine($"Здоровье второго бойца: {EndHealth2:F1}");

                CountHit++; //увеличивает счётчик после 1-ого удара

                if (EndHealth2 <= 0) break; //елси 2-ой боец умер, он не должен
                                            //бить в ответ

                //Удар ВТОРОГО бойца по ПЕРВОМУ
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Удар номер {CountHit + 1}"); //Пишет номер удара

                Console.ForegroundColor = ConsoleColor.Black;
                RandomDamage2 = minDamage2 + rand.NextDouble() * (maxDamage2 - minDamage2);
                Console.WriteLine("===============================================");
                Console.WriteLine($"Второй боец наносит удар силой: {RandomDamage2:F1}");

                Damage2 = RandomDamage2 - (RandomDamage2 * Armor1 / 100);
                Console.WriteLine($"Итоговый урон у второго бойца (с учётом брони): {Damage2:F1}");

                EndHealth1 -= Damage2;
                if (EndHealth1 < 0) EndHealth1 = 0;
                Console.WriteLine($"Здоровье первого бойца: {EndHealth1:F1}");

                CountHit++; //увеличивает счётчик после 2-ого удара

                Console.ForegroundColor = ConsoleColor.Black;

            }





            //Проверка здоровья для вывода сообщения
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("===============================================");
            if (EndHealth1 <= 0 && EndHealth2 <= 0)
            {
                Console.WriteLine($"Ничья. Оба погибли. Всего ударов: {CountHit}");
            }
            else if (EndHealth2 <= 0)
            {
                Console.WriteLine($"Победил первый гладиатор. Всего ударов: {CountHit}");
            }
            else if (EndHealth1 <= 0)
            {
                Console.WriteLine($"Победил второй гладиатор. Всего ударов: {CountHit}");
            }

            Console.ReadKey();
        }
    }
}
