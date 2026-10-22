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
            double StartHealth1, Armor1, Damage1, EndDamage1, EndHealth1;
            double StartHealth2, Armor2, Damage2, EndDamage2, EndHealth2;
            string Text;



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
                Console.WriteLine("Ошибка! Крепость брони должна составлять от 0 до 100 %");
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
                Console.WriteLine("Ошибка! Крепость брони должна составлять от 0 до 100 %");
                goto rep1;
            }


            //Расчёт здоровья, удара у первого бойца
            Damage1 = rand.NextDouble() * 100 * (Armor1/100);
            Console.WriteLine($"Первому бойцу нанесли урон: {Damage1:F1}");

            EndDamage1 = Damage1 * (1 - (Armor1 / 100));
            Console.WriteLine($"Итоговый урон у первого бойца: {EndDamage1:F1}");

            EndHealth1 = StartHealth1 - EndDamage1;
            Console.WriteLine($"Итоговое здоровье у первого бойца: {EndHealth1:F1}");



            
            //Расчёт здоровья, удара у второго бойца
            Damage2 = rand.NextDouble() * 100 * (Armor2 / 100);
            Console.WriteLine($"Второму бойцу нанесли урон: {Damage2:F1}");

            EndDamage2 = Damage2 * (1 - (Armor2 / 100));
            Console.WriteLine($"Итоговый урон у второго бойца: {EndDamage2:F1}");

            EndHealth2 = StartHealth2 - EndDamage2;
            Console.WriteLine($"Итоговое здоровье у второго бойца: {EndHealth2:F1}");

            
            
            //Проверка здоровья для вывода сообщения
            if (EndHealth1 > EndHealth2)
            {
                Console.WriteLine("Победил первый гладиатор");
            }

            if (EndHealth1 < EndHealth2)
            {
                Console.WriteLine("Победил второй гладиатор");
            }

             if (EndHealth1 == EndHealth2)
             {
                Console.WriteLine("Ничья. Никто не одержал победу.");
             }

            if (EndHealth1 < 0 && EndHealth2 < 0)
            {
                Console.WriteLine("Оба погибли.");
            }

            Console.ReadKey();
        }
    }
}
