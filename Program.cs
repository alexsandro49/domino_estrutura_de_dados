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
                mesa.AtualizarJogo("jogador", peca);
            }

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
                        Console.Write("    1");
                        for (byte i = 2; i <= jogoP.Count; i ++)
                        {
                            Console.Write($"         {i}");
                        }
                        Console.WriteLine();
                        break;
                    }
                    else if (opc == "3")
                    {
                        Console.WriteLine();
                        Console.WriteLine("QUAL PEÇA JOGAR?");
                        mesa.PecasJogador();
                        while (true)
                        {
                            Console.Write(": ");
                            opc = Console.ReadLine();
                            if (opc == "1" && jogoP.Count >= 1)
                            {
                                mesa.RemoverPeca("jogador", jogoP[0]);
                                jogoP.Remove(jogoP[0]);
                                break;
                            }
                            else if (opc == "2" && jogoP.Count >= 1)
                            {
                                mesa.RemoverPeca("jogador", jogoP[1]);
                                jogoP.Remove(jogoP[1]);
                                break;
                            }
                            else if (opc == "3" && jogoP.Count >= 2)
                            {
                                mesa.RemoverPeca("jogador", jogoP[2]);
                                jogoP.Remove(jogoP[2]);
                                break;
                            }
                            else if (opc == "4" && jogoP.Count >= 3)
                            {
                                mesa.RemoverPeca("jogador", jogoP[3]);
                                jogoP.Remove(jogoP[3]);
                                break;
                            }
                            else if (opc == "5" && jogoP.Count >= 4)
                            {
                                mesa.RemoverPeca("jogador", jogoP[4]);
                                jogoP.Remove(jogoP[4]);
                                break;
                            }
                            else if (opc == "6" && jogoP.Count >= 5)
                            {
                                mesa.RemoverPeca("jogador", jogoP[5]);
                                jogoP.Remove(jogoP[5]);
                                break;
                            }
                            else if (opc == "7" && jogoP.Count >= 6)
                            { 
                                mesa.RemoverPeca("jogador", jogoP[6]);
                                jogoP.Remove(jogoP[6]);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida. Por favor, tente novamente!");
                            }
                        }
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