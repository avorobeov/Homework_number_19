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
            Random random = new Random();
            int numberFights;
            int numberWins = 0;
            int numberDefeats = 0;
            int numberOfDraws = 0;

            Console.Write("Укажите сколько раз бойцы будут сражаться: ");
            numberFights = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberFights; i++)
            {
                bool isSpiritSummoned = false;
                bool isThereProtection = false;
                int amountLifeHeros = 1000;
                int amountLifeBoss = 1000;
                int herosDamage = 30;
                int maxBossDamage = 150;
                int minBossDamage = 50;
                int spiritDamage = 100;
                int riftSpellLifeBoost = 250;
                int numberSpells = 4;

                while (amountLifeHeros > 0 && amountLifeBoss > 0)
                {
                    switch (random.Next(0, numberSpells))
                    {
                        case 0:
                            if (isSpiritSummoned == false)
                            {
                                isSpiritSummoned = true;
                                amountLifeHeros -= spiritDamage;
                            }
                            break;

                        case 1:
                            if (isSpiritSummoned == true)
                            {
                                amountLifeBoss -= spiritDamage;
                                isSpiritSummoned = false;
                            }
                            break;

                        case 2:
                            if (isThereProtection == false)
                            {
                                amountLifeHeros += riftSpellLifeBoost;
                                isThereProtection = true;
                            }
                            break;

                        case 3:
                            if (isSpiritSummoned == true)
                            {
                                amountLifeHeros -= spiritDamage;
                                amountLifeBoss -= spiritDamage;
                                isThereProtection = true;
                                isSpiritSummoned = false;
                            }
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
                    numberOfDraws++;

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"К сожалению оба бойца мертвы");
                }
                else if (amountLifeHeros <= 0)
                {
                    numberDefeats++;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"К сожалению герой умер");
                }
                else if (amountLifeBoss <= 0)
                {
                    numberWins++;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Вы победили бос повержан");
                }
            }

            Console.Clear();
            Console.WriteLine($"Вы победили количество раз: : {numberWins}\n" +
                              $"Вы проиграли количество раз: {numberDefeats}\n" +
                              $"Количество ничьих: {numberOfDraws}\n");
            Console.ReadKey();
        }
    }
}
