using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace domino_estrutura_de_dados
{
    class Program
    {
        static List<string> pecas = new List<string>() { "00", "01", "11", "02", "12", "22", "03", "13", "23", "33", "04", "14", "24", "34", "44", "05", "15", "25", "35", "45", "55", "06", "16", "26", "36", "46", "56", "66" };
        static void Main(string[] args)
        {
            PecasJogadas mesa = new PecasJogadas();

            //gerar os jogos
            List<string> pecasP = NovoJogoP();
            List<string> pecasC = NovoJogoC(pecasP);

            for (int i = 0; i < pecasC.Count; i++)
            {
                Peca peca = new Peca(pecasC[i]);
                //mesa.AtualizarJogoC(peca);
                mesa.Adicionar(peca);
            }

            for (int i = 0; i < pecasP.Count; i++)
            {
                Peca peca = new Peca(pecasP[i]);
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
                        mesa.LinhaPecas(mesa.linhaP);
                        Console.Write("    1");
                        for (byte i = 2; i <= pecasP.Count; i++)
                        {
                            Console.Write($"         {i}");
                        }
                        Console.WriteLine("\n");
                        break;
                    }
                    else if (opc == "3")
                    {
                        Console.WriteLine();
                        Console.WriteLine("QUAL PEÇA JOGAR?");
                        mesa.LinhaPecas(mesa.linhaP);
                        while (true)
                        {
                            string[] opcoes = { "1", "2", "3", "4", "5", "6", "7" };
                            Console.Write(": ");
                            opc = Console.ReadLine();
                            if (opcoes.Contains(opc) && pecasP.Count >= int.Parse(opc.Substring(0, 1)))
                            {
                                while (true)
                                {
                                    string opc1 = mesa.PecaEscolhida(sbyte.Parse(opc.Substring(0, 1)));
                                    if (opc1 == "1" || opc1 == "2")
                                    {
                                        if (opc1 == "1")
                                        {
                                            //if (mesa.adicionaInicio) {
                                        }
                                        else
                                        {
                                            //if (mesa.adicionaFinal) {
                                        }
                                        //mesa.RemoverPeca("jogador", pecasP[0]);
                                        //pecasP.Remove(pecasP[0]);
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
                        break;
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, tente novamente!");
                    }
                    break;
                }
            }

        }

        public static List<string> NovoJogoP()
        {
            List<string> pecasP = new List<string>();
            while (pecasP.Count < 7)
            {
                Random random = new Random();
                string peca = pecas[random.Next(0, 28)];
                if (!pecasP.Contains(peca))
                {
                    pecasP.Add(peca);
                }
            }
            return pecasP;
        }

        public static List<string> NovoJogoC(List<string> pecasP)
        {
            List<string> pecasC = new List<string>();
            while (pecasC.Count < 7)
            {
                Random random = new Random();
                string peca = pecas[random.Next(0, 28)];
                if (!pecasP.Contains(peca) && !pecasC.Contains(peca))
                {
                    pecasC.Add(peca);
                }
            }
            return pecasC;
        }
    }
}