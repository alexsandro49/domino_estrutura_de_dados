using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicaJogo mesa = new LogicaJogo();

            List<string> valoresPecasJogador = mesa.NovoJogoP();
            List<string> valoresPecasComputador = mesa.NovoJogoC(valoresPecasJogador);

            for (int i = 0; i < valoresPecasJogador.Count; i++)
            {
                Peca peca = new Peca(valoresPecasJogador[i]);
                mesa.AdicionarPeca("jogador", peca);
            }
            
            for (int i = 0; i < valoresPecasComputador.Count; i++)
            {
                Peca peca = new Peca(valoresPecasComputador[i]);
                mesa.AdicionarPeca("computador", peca);
            }
            
            valoresPecasJogador.Sort();
            valoresPecasComputador.Sort();
            mesa.InicioJogo(valoresPecasJogador, valoresPecasComputador);
            bool fim = false;

            while (true)
            {
                mesa.JogadorTravado();
                fim = mesa.FimDeJogo();
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
                    for (byte i = 0; i < mesa.pecasJogador.Count; i++)
                    {
                        lista.Add(mesa.pecasJogador[i].valores);
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
                        mesa.DesenharPecas(lista);
                        Console.Write("    1");
                        for (byte i = 2; i <= mesa.pecasJogador.Count; i++)
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
                            mesa.DesenharPecas(lista);
                            Console.Write(": ");
                            opc = Console.ReadLine();
                            if (opcoes.Contains(opc) && valoresPecasJogador.Count >= int.Parse(opc.Substring(0, 1)))
                            {
                                while (true)
                                {
                                    bool validade;
                                    string opc1 = mesa.PecaEscolhida(sbyte.Parse(opc.Substring(0, 1)));
                                    if (opc1 == "1" || opc1 == "2")
                                    {
                                        if (opc1 == "1")
                                        {
                                            validade = mesa.JogarPeca("inicio", mesa.pecasJogador[int.Parse(opc.Substring(0, 1))-1]);
                                        }
                                        else
                                        {
                                            validade = mesa.JogarPeca("final", mesa.pecasJogador[int.Parse(opc.Substring(0, 1)) - 1]);
                                        }

                                        if (validade)
                                        {
                                            mesa.RemoverPeca("jogador", mesa.pecasJogador[int.Parse(opc.Substring(0, 1)) - 1]);
                                            mesa.JogadaComputador();
                                            break;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\nPeça inválida!");
                                            Console.ResetColor();
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
    }
}