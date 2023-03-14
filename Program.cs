using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    class Program
    {
        static List<string> pecas = new List<string>() { "00", "01", "11", "02", "12", "22", "03", "13", "23", "33", "04", "14", "24", "34", "44", "05", "15", "25", "35", "45", "55", "06", "16", "26", "36", "46", "56", "66" };
        static void Main(string[] args)
        {
            LogicaJogo mesa = new LogicaJogo();

            List<string> pecasP = NovoJogoP();
            List<string> pecasC = NovoJogoC(pecasP);

            for (int i = 0; i < pecasP.Count; i++)
            {
                Peca peca = new Peca(pecasP[i]);
                mesa.AtualizarJogo("jogador", peca);
            }
            
            for (int i = 0; i < pecasC.Count; i++)
            {
                Peca peca = new Peca(pecasC[i]);
                mesa.AtualizarJogo("computador", peca);
            }
            
            pecasP.Sort();
            pecasC.Sort();
            mesa.InicioJogo(pecasP, pecasC);
            bool fim = false;

            while (true)
            {
                mesa.JogadorTravado();
                fim = mesa.FimDeJogo(pecasP, pecasC);

                if (fim)
                {
                    Console.WriteLine("Jogo finalizado!");
                    return;
                }

                Console.WriteLine("\n1 - OLHAR PEÇAS NA MESA");
                Console.WriteLine("2 - SUAS PEÇAS");
                Console.WriteLine("3 - JOGAR UMA PEÇA");
                Console.WriteLine("4 - PULAR JOGADA");
                Console.WriteLine("      ------");
                Console.WriteLine("0 - SAIR DO JOGO");
                while (true)
                {
                    List<string> lista = new List<string>();
                    for (byte i = 0; i < mesa.linhaP.Count; i++)
                    {
                        lista.Add(mesa.linhaP[i].valores);
                    }

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
                        mesa.LinhaPecas(lista);
                        Console.Write("    1");
                        for (byte i = 2; i <= mesa.linhaP.Count; i++)
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
                        string[] opcoes = { "1", "2", "3", "4", "5", "6", "7" };
                        while (true)
                        {
                            bool escolhaCancelada = false;
                            mesa.LinhaPecas(lista);
                            Console.Write(": ");
                            opc = Console.ReadLine();
                            if (opcoes.Contains(opc) && pecasP.Count >= int.Parse(opc.Substring(0, 1)))
                            {
                                while (true)
                                {
                                    bool validade;
                                    string opc1 = mesa.PecaEscolhida(sbyte.Parse(opc.Substring(0, 1)));
                                    if (opc1 == "1" || opc1 == "2")
                                    {
                                        if (opc1 == "1")
                                        {
                                            validade = mesa.JogarPeca("inicio", mesa.linhaP[int.Parse(opc.Substring(0, 1))-1]);
                                        }
                                        else
                                        {
                                            validade = mesa.JogarPeca("final", mesa.linhaP[int.Parse(opc.Substring(0, 1)) - 1]);
                                        }

                                        if (validade)
                                        {
                                            mesa.RemoverPeca("jogador", mesa.linhaP[int.Parse(opc.Substring(0, 1)) - 1]);
                                            mesa.JogadaComputador();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Peça inválida!");
                                            mesa.JogadaComputador();
                                            break;
                                        }
                                    }
                                    else if (opc1 == "0")
                                    {
                                        escolhaCancelada = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção inválida. Por favor, tente novamente!");
                                    }
                                }
                                if (escolhaCancelada)
                                {
                                    continue;
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida. Por favor, tente novamente!\n");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (opc == "4")
                    {
                        mesa.JogadaComputador();
                    }
                    else if (opc == "0")
                    {
                        Console.WriteLine("Jogo finalizado!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, tente novamente!\n");
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