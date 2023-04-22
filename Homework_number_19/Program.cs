using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_number_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandCallSpirit = 1;
            const int CommandAttackSpirit = 2;
            const int CommandRift = 3;
            const int CommandProtection = 4;

            Random random = new Random();
            bool isSpiritSummoned = false;
            bool isThereProtection = false;
            int amountLifeHeros = 1000;
            int amountLifeBoss = 1000;
            int herosDamage = 30;
            int maxBossDamage = 150;
            int minBossDamage = 50;
            int spiritDamage = 100;
            int riftSpellLifeBoost = 250;
            int userInput;

            Console.Write($"Вы теневой маг по имени Алиас вам нужно победить боса который встретился вам на пути для этого у вас есть {4}" +
                          $" заклинания для того что бы их использовать вам нужно указать его номер\n");

            while (amountLifeHeros > 0 && amountLifeBoss > 0)
            {
                Console.Write($"{CommandCallSpirit}) Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)\n" +
                              $"{CommandAttackSpirit}) Хуганзакура(Может быть выполнен только после призыва теневого духа), наносит 100 ед.урона\n" +
                              $"{CommandRift}) Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп.Урон босса по вам не проходит\n" +
                              $"{CommandProtection}) Мамарзакура = наносит вам и босу урон в размере {spiritDamage}хп но даёт вам  не уязвимость на один ход" +
                              $"Укажите номер заклинания Которое вы хотите использовать:");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case CommandCallSpirit:
                        if (isSpiritSummoned == false)
                        {
                            isSpiritSummoned = true;
                            amountLifeHeros -= spiritDamage;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Вы вызвали духа и получили урона ({isSpiritSummoned})хп ");
                        }
                        break;

                    case CommandAttackSpirit:
                        if (isSpiritSummoned == true)
                        {
                            amountLifeBoss -= spiritDamage;
                            isSpiritSummoned = false;

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Дух нанёс урон боссу ({isSpiritSummoned})хп");
                        }
                        break;

                    case CommandRift:
                        if (isThereProtection == false)
                        {
                            amountLifeHeros += riftSpellLifeBoost;
                            isThereProtection = true;

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"Вы спрятались в разлом, восстановили {riftSpellLifeBoost} хп и получили щит на один ход");
                        }
                        break;

                    case CommandProtection:
                        if (isSpiritSummoned == true)
                        {
                            amountLifeHeros -= spiritDamage;
                            amountLifeBoss -= spiritDamage;
                            isThereProtection = true;
                            isSpiritSummoned = false;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Дух наносит вам и босу урон в размере {spiritDamage} хп но при этом даёт вам щит на один ход");
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"К сожалению не удалось использовать заклинание");
                        break;

                }

                if (isThereProtection == false)
                {
                    amountLifeHeros -= random.Next(minBossDamage, maxBossDamage);
                    amountLifeBoss -= herosDamage;
                }
                else if (isThereProtection == true)
                {
                    isThereProtection = false;
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"********************\n" +
                                  $"Количество жизни босса: {amountLifeBoss}\n" +
                                  $"Количество жизни героя: {amountLifeHeros}");

            }

            if (amountLifeHeros <= 0 && amountLifeBoss <= 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"К сожалению оба бойца мертвы");
            }
            else if (amountLifeHeros <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"К сожалению герой умер");
            }
            else if (amountLifeBoss <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Вы победили бос повержан");
            }

            Console.ReadKey();
        }
    }
}
