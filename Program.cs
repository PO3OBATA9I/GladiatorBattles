using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
            string Text;

            //Цвет заднего фона и текста + заголовок
            Console.Title = "Бой двух гладиаторов";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            //Ввод здоровья и % брони для ПЕРВОГО бойца
            Console.WriteLine("Введите начальный уровень здоровья у первого бойца: ");
            Text = Console.ReadLine();
            StartHealth1 = Convert.ToDouble(Text);

            rep: Console.WriteLine("Введите крепость брони у первого бойца (в %): ");
            Text = Console.ReadLine();
            Armor1 = Convert.ToDouble(Text);

            
            //Проверка крепости брони 1
            if (Armor1 < 0 || Armor1 > 100)
            {
                Console.WriteLine("Ошибка! Крепость брони должна быть от 0 до 100 %");
                goto rep;
            }


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
                Console.WriteLine("Ошибка! Крепость брони должна быть от 0 до 100 %");
                goto rep1;
            }

            EndHealth1 = StartHealth1;
            EndHealth2 = StartHealth2;
            int CountHit = 0;

            for (; EndHealth1 > 0 && EndHealth2 > 0; ) 
            {
                //Удар ПЕРВОГО бойца по ВТОРОМУ
                RandomDamage1 = rand.NextDouble() * 100; //Генерация случайного урона у ПЕРВОГО бойца(адекватное число)
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
                RandomDamage2 = rand.NextDouble() * 100; //Генерация случайного урона у ВТОРОГО бойца (адекватное число)
                Console.WriteLine("===============================================");
                Console.WriteLine($"Второй боец наносит удар силой: {RandomDamage2:F1}");

                Damage2 = RandomDamage2 - (RandomDamage2 * Armor1 / 100);
                Console.WriteLine($"Итоговый урон у второго бойца (с учётом брони): {Damage2:F1}");

                EndHealth1 -= Damage2;
                if (EndHealth1 < 0) EndHealth1 = 0;
                Console.WriteLine($"Здоровье первого бойца: {EndHealth1:F1}");

                CountHit++; //увеличивает счётчик после 2-ого удара
            }


            //Проверка здоровья для вывода сообщения
            Console.WriteLine("===============================================");
            if (EndHealth2 <= 0)
            {
                Console.WriteLine($"Победил первый гладиатор. Всего ударов: {CountHit}");
            }
            else if (EndHealth1 <= 0)
            {
                Console.WriteLine($"Победил второй гладиатор. Всего ударов: {CountHit}");
            }
            else if (EndHealth1 <= 0 && EndHealth2 <= 0)
            {
                Console.WriteLine($"Ничья. Никто не одержал победу. Всего ударов: {CountHit}");
            }

            Console.ReadKey();
        }
    }
}
