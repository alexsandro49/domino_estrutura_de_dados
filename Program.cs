using System;
using System.Globalization;

namespace domino_estrutura_de_dados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            string[] pecas = {"0 | 0", "0 | 1", "1 | 1", "0 | 2", "1 | 2", "2 | 2", "0 | 3", "1 | 3", "2 | 3", "3 | 3", "0 | 4", "1 | 4", "2 | 4", "3 | 4", "4 | 4", "0 | 5", "1 | 5", "2 | 5", "3 | 5", "4 | 5", "5 | 5", "0 | 6", "1 | 6", "2 | 6", "3 | 6", "4 | 6", "5 | 6", "6 | 6"};

            //Random random = new Random();
            ConsoleColor corDetalhes, corPeca;
            string opcCorPeca, opcCorNumeros;

            Console.WriteLine("Escolha a cor das peças: ");
            Console.WriteLine("1 - BRANCO");
            Console.WriteLine("2 - PRETO");
            while (true)
            {
                Console.Write(": ");
                opcCorPeca = Console.ReadLine().Trim();
                if (opcCorPeca == "1")
                {
                    corPeca = ConsoleColor.White;
                    break;
                }
                else if (opcCorPeca == "2")
                {
                    corPeca = ConsoleColor.Black;
                    break;
                }

                else
                {
                    Console.WriteLine("Opção inválida! Por favor, tente novamente.");
                }
            }


            Console.WriteLine("Escolha a cor dos números: ");
            Console.WriteLine("1 - VERMELHO");
            Console.WriteLine("2 - AZUL");
            Console.WriteLine("3 - AMARELO");
            Console.WriteLine("4 - VERDE");
            if (opcCorPeca == "1")
            {
                Console.WriteLine("5 - PRETO");
            }
            else
            {
                Console.WriteLine("5 - BRANCO");
            }
            while (true)
            {
                Console.Write(": ");
                opcCorNumeros = Console.ReadLine().Trim();
                if (opcCorNumeros == "1")
                {
                    corDetalhes = ConsoleColor.Red;
                    break;
                }
                else if (opcCorNumeros == "2")
                {
                    corDetalhes = ConsoleColor.Blue;
                    break;
                }
                else if (opcCorNumeros == "3")
                {
                    corDetalhes = ConsoleColor.Yellow;
                    break;
                }
                else if (opcCorNumeros == "4")
                {
                    corDetalhes = ConsoleColor.Green;
                    break;
                }
                else if (opcCorNumeros == "5")
                {
                    if (opcCorPeca == "1")
                    {
                        corDetalhes = ConsoleColor.Black;
                    }
                    else
                    {
                        corDetalhes = ConsoleColor.White;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Por favor, tente novamente.");
                }
            }


            for (int i = 0; i < pecas.Length; i++)
            {
                Console.ForegroundColor = corDetalhes;
                Console.BackgroundColor = corPeca;
                if (i > 0 && i % 7 == 0)
                {
                    Console.WriteLine();
                }

                Console.Write($"{pecas[i]}");
                Console.ResetColor();
                Console.Write(" ");
            }
            Console.WriteLine();

            //Console.Clear();
        }
    }
}