using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    class Program
    {
        static List<string> pecas = new List<string>() { "00", "01", "11", "02", "12", "22", "03", "13", "23", "33", "04", "14", "24", "34", "44", "05", "15", "25", "35", "45", "55", "06", "16", "26", "36", "46", "56", "66" };
        static void Main(string[] args)
        {
            PecasJogadas mesa = new PecasJogadas();

            //gerar os jogos
            List<string> jogoP = NovoJogoP();
            List<string> jogoC = NovoJogoC(jogoP);

            for (int i = 0; i < jogoC.Count; i++)
            {
                Peca peca = new Peca(jogoC[i]);
                //mesa.AtualizarJogoC(peca);
                mesa.Adicionar(peca);
            }


            for (int i = 0; i < jogoP.Count; i++)
            {
                Peca peca = new Peca(jogoP[i]);
                mesa.AtualizarJogoP(peca);
            }


            // mesa.Mostrar();

            while (true)
            {
                Console.WriteLine("1 - OLHAR PEÇAS NA MESA");
                Console.WriteLine("2 - SUAS PEÇAS");
                Console.WriteLine("3 - JOGAR UMA PEÇA");
                while (true)
                {
                    Console.Write(": ");
                    string opc = Console.ReadLine();

                    if (opc == "1")
                    {
                        Console.WriteLine();
                        Console.WriteLine("PEÇAS NA MESA:");
                        mesa.PecasNaMesa();
                        Console.WriteLine();
                        break;
                    }
                    else if (opc == "2")
                    {
                        Console.WriteLine();
                        Console.WriteLine("PEÇAS DO JOGADOR:");
                        mesa.PecasJogador();
                        Console.WriteLine("    1         2         3         4         5         6         7");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, tente novamente!");
                    }
                }
            }

        }

        public static List<string> NovoJogoP()
        {
            List<string> jogoP = new List<string>();
            while (jogoP.Count < 7)
            {
                Random random = new Random();
                string peca = pecas[random.Next(0, 28)];
                if (!jogoP.Contains(peca))
                {
                    jogoP.Add(peca);
                }
            }
            return jogoP;
        }

        public static List<string> NovoJogoC(List<string> jogoP)
        {
            List<string> jogoC = new List<string>();
            while (jogoC.Count < 7)
            {
                Random random = new Random();
                string peca = pecas[random.Next(0, 28)];
                if (!jogoP.Contains(peca) && !jogoC.Contains(peca))
                {
                    jogoC.Add(peca);
                }
            }
            return jogoC;
        }
    }
}