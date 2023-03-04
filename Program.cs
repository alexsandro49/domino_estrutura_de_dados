using System;
using System.Globalization;

namespace domino_estrutura_de_dados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            string[] pecas = new string[5];

            pecas[0] = "0 | 0";
            pecas[1] = "0 | 1";
            pecas[2] = "1 | 3";
            pecas[3] = "3 | 5";
            pecas[4] = "5 | 5";

            Random random = new Random();
            ConsoleColor[] corDetalhes = new ConsoleColor[pecas.Length];
            ConsoleColor[] corPeca = new ConsoleColor[pecas.Length];

            for (int i = 0; i < pecas.Length; i++)
            {
                corDetalhes[i] = (ConsoleColor)random.Next(1, 16);
                if (i % 2 == 0)
                {
                    corPeca[i] = ConsoleColor.Black;
                }
                else
                {
                    corPeca[i] = ConsoleColor.White;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = corDetalhes[i];
                Console.BackgroundColor = corPeca[i];
                Console.Write($"\u001b[1m{pecas[i]}\u001b[0m");
                Console.ResetColor();
                Console.Write(" ");
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}