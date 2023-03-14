using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    internal class LogicaJogo
    {
        private string linha1 = "---------";
        private PecasJogadas pecasJogadas = new PecasJogadas();

        public List<Peca> linhaP = new List<Peca>();
        public List<Peca> linhaC = new List<Peca>();

        Random random = new Random();
        bool computadorTravado = false;

        public void AtualizarJogo(string jogo, Peca peca)
        {
            if (jogo == "jogador")
            {
                if (linhaP.Count < 7)
                {
                    linhaP.Add(peca);
                }
            }
            else
            {
                if (linhaC.Count < 7)
                {
                    linhaC.Add(peca);
                }
            }
        }

        public void RemoverPeca(string jogo, Peca peca)
        {
            if (jogo == "jogador")
            {
                linhaP.Remove(peca);
            }
            else
            {
                linhaC.Remove(peca);
            }
        }

        public bool JogarPeca(string opcao, Peca peca)
        {
            bool validade = pecasJogadas.Inserir(peca, opcao);
            return validade;
        }

        public void Linhas(int w, int x = -1, int y = -1, int z = -1)
        {
            for (int i = 0; i < w; i++)
            {
                if ((x > -1 && i == x) || (i == 0 && y > -1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if ((i == w-1 && (y > -1 && y < 8)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if ((i == w-1 && (z > -1)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                } 

                Console.Write($"{linha1} ");
                Console.ResetColor();
            }
        }

        public void LinhaPecas(List<string> x, sbyte pos = -1)
        {
            if (pos == -1)
            {
                Linhas(x.Count);
                Console.WriteLine();
                for (byte i = 0; i < x.Count; i++)
                {
                    if (i > 0 && i % 7 == 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write($"{x[i]} ");
                }
                Console.WriteLine();
                Linhas(x.Count);
                Console.WriteLine();
            }
            else
            {
                Linhas(x.Count, pos);
                Console.WriteLine();
                for (int i = 0; i < x.Count; i++)
                {
                    if (i == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write($"{x[i]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Linhas(x.Count, pos);
                Console.WriteLine();
            }
        }
        public string PecaEscolhida(sbyte pos)
        {
            List<string> lista = new List<string>();
            foreach (var item in linhaP)
            {
                lista.Add(item.valores);
            }

            if (PecasJogadas.cabeca == null)
            {
                return "1";
            }

            Console.WriteLine();
            LinhaPecas(lista, (sbyte)(pos - 1));
            Console.WriteLine();
            Console.WriteLine("1 - PEÇA NO INÍCIO ");
            Console.WriteLine("2 - PEÇA NO FINAL");
            Console.WriteLine("0 - CANCELAR");
            Console.Write(": ");
            string opc1 = Console.ReadLine();
            return opc1.Substring(0, 1);
        }

        public void PecasNaMesa()
        {
            List<string> x = pecasJogadas.Mostrar();
            byte k;

            if (x.Count > 0)
            {
                if (x.Count <= 7)
                {
                    Linhas(x.Count, -1, x.Count);
                    k = (byte)x.Count;
                }
                else
                {
                    Linhas(7, -1, x.Count);
                    k = 7;
                }

                Console.WriteLine();
                for (byte i = 0; i < k; i++)
                {
                    if ((i == 0) || ((i == k-1) && (x.Count < 8)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write($"{x[i]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
                if (x.Count <= 7)
                {
                    Linhas(x.Count, -1, x.Count);
                }
                else
                {
                    Linhas(7, -1, x.Count);
                }
                Console.WriteLine();
            }
            if (x.Count > 7)
            {
                Linhas(x.Count - 7, -1, -1, x.Count);
                k = (byte)x.Count;

                Console.WriteLine();
                for (byte i = 7; i < k; i++)
                {
                    if (i == k - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write($"{x[i]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();

                Linhas(x.Count - 7, -1, -1, x.Count);
                Console.WriteLine();
            }
        }

        public void InicioJogo(List<string> jogoP, List<string> jogoC)
        {
            List<string> bombas = new List<string> { "00", "11", "22", "33", "44", "55", "66" };
            List<string> bombasP = new List<string>();
            List<string> bombasC = new List<string>();

            foreach (var item in jogoP)
            {
                if (bombas.Contains(item))
                {
                    bombasP.Add(item);
                }
            }

            foreach (var item in jogoC)
            {
                if (bombas.Contains(item))
                {
                    bombasC.Add(item);
                }

            }
            bool validade = false;
            Peca pecaRemovida = linhaP[0];

            if (bombasP.Count > 0 && bombasC.Count > 0)
            {
                if (byte.Parse(bombasP[bombasP.Count - 1]) > byte.Parse(bombasC[bombasC.Count - 1]))
                {
                    Console.Write("O jogador inicia com a peca: ");
                    string ladoA = bombasP[bombasP.Count - 1].Substring(0, 1);
                    string ladoB = bombasP[bombasP.Count - 1].Substring(1, 1);
                    foreach (var item in linhaP)
                    {
                        if (item.valores == $"| {ladoA} | {ladoB} |")
                        {
                            Console.WriteLine(item.valores);
                            validade = JogarPeca("inicio", item);
                            pecaRemovida = item;
                            break;
                        }
                    }
                    if (validade)
                    {
                        RemoverPeca("jogador", pecaRemovida);
                        JogadaComputador();
                    }
                }
                else
                {
                    Console.Write("O computador inicia com a peca: ");
                    string ladoA = bombasC[bombasC.Count - 1].Substring(0, 1);
                    string ladoB = bombasC[bombasC.Count - 1].Substring(1, 1);
                    foreach (var item in linhaC)
                    {
                        if (item.valores == $"| {ladoA} | {ladoB} |")
                        {
                            Console.WriteLine(item.valores);
                            validade = JogarPeca("inicio", item);
                            pecaRemovida = item;
                            break;
                        }
                    }
                    if (validade)
                    {
                        RemoverPeca("computador", pecaRemovida);
                    }
                }
            }
            else if (bombasP.Count > 0)
            {
                Console.Write("O jogador inicia com a peca: ");
                string ladoA = bombasP[bombasP.Count - 1].Substring(0, 1);
                string ladoB = bombasP[bombasP.Count - 1].Substring(1, 1);
                foreach (var item in linhaP)
                {
                    if (item.valores == $"| {ladoA} | {ladoB} |")
                    {
                        Console.WriteLine(item.valores);
                        validade = JogarPeca("inicio", item);
                        pecaRemovida = item;
                        break;
                    }
                }
                if (validade)
                {
                    RemoverPeca("jogador", pecaRemovida);
                    JogadaComputador();
                }
            }
            else if (bombasC.Count > 0)
            {
                Console.Write("O computador inicia com a peca: ");
                string ladoA = bombasC[bombasC.Count - 1].Substring(0, 1);
                string ladoB = bombasC[bombasC.Count - 1].Substring(1, 1);
                foreach (var item in linhaC)
                {
                    if (item.valores == $"| {ladoA} | {ladoB} |")
                    {
                        Console.WriteLine(item.valores);
                        validade = JogarPeca("inicio", item);
                        pecaRemovida = item;
                        break;
                    }
                }
                if (validade)
                {
                    RemoverPeca("computador", pecaRemovida);
                }
            }
            else
            {
                byte maiorP = byte.Parse(jogoP[jogoP.Count - 1]);
                byte maiorC = byte.Parse(jogoC[jogoC.Count - 1]);
                if (maiorP > maiorC)
                {
                    Console.Write("O jogador inicia com a peca: ");
                    string ladoA = jogoP[jogoP.Count - 1].Substring(0, 1);
                    string ladoB = jogoP[jogoP.Count - 1].Substring(1, 1);
                    foreach (var item in linhaP)
                    {
                        if (item.valores == $"| {ladoA} | {ladoB} |")
                        {
                            Console.WriteLine(item.valores);
                            validade = JogarPeca("inicio", item);
                            pecaRemovida = item;
                            break;
                        }
                    }
                    if (validade)
                    {
                        RemoverPeca("jogador", pecaRemovida);
                        JogadaComputador();
                    }
                }
                else
                {
                    Console.Write("O computador inicia com a peca: ");
                    string ladoA = jogoC[jogoC.Count - 1].Substring(0, 1);
                    string ladoB = jogoC[jogoC.Count - 1].Substring(1, 1);
                    foreach (var item in linhaC)
                    {
                        if (item.valores == $"| {ladoA} | {ladoB} |")
                        {
                            Console.WriteLine(item.valores);
                            validade = JogarPeca("inicio", item);
                            pecaRemovida = item;
                            break;
                        }
                    }
                    if (validade)
                    {
                        RemoverPeca("computador", pecaRemovida);
                    }
                }
            }
        }
        public void JogadaComputador()
        {
            List<Peca> pecasComputador = new List<Peca>();
            bool validade = true;

            foreach (var item in linhaC)
            {
                if (pecasJogadas.Testar(item, "inicio") || pecasJogadas.Testar(item, "final"))
                {
                    pecasComputador.Add(item);
                }
            }

            if (pecasComputador.Count > 0)
            {
                Peca pecaAleatoria = pecasComputador[random.Next(pecasComputador.Count)];
                validade = JogarPeca("inicio", pecaAleatoria);
                if (!validade)
                {
                    JogarPeca("final", pecaAleatoria);
                }
                RemoverPeca("computador", pecaAleatoria);
                Console.WriteLine($"\nO computador jogou: {pecaAleatoria.valores}");
            }
            else
            {
                Console.WriteLine("O computador não tem peças compatíveis!");
                computadorTravado = true;
            }

            return;
        }

        public bool JogadorTravado()
        {
            List<Peca> pecasJogador = new List<Peca>();

            foreach (var item in linhaP)
            {
                if (pecasJogadas.Testar(item, "inicio") || pecasJogadas.Testar(item, "final"))
                {
                    pecasJogador.Add(item);
                }
            }

            if (pecasJogador.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ContarPontos(List<string> jogoP, List<string> jogoC)
        {
            int somaP = 0, somaC = 0;

            foreach (var item in jogoP)
            {
                somaP += (int.Parse(item.Substring(0, 1)) + int.Parse(item.Substring(1, 1)));
            }

            foreach (var item in jogoC)
            {
                somaC += (int.Parse(item.Substring(0, 1)) + int.Parse(item.Substring(1, 1)));
            }

            Console.WriteLine($"\nPONTOS DO JOGADOR: {somaP}");
            Console.WriteLine($"PONTOS DO COMPUTADOR: {somaC}");

            if (somaP < somaC)
            {
                Console.WriteLine("O JOGADOR VENCEU!");
            }
            else if (somaC < somaP)
            {
                Console.WriteLine("O COMPUTADOR VENCEU!");
            }
            else
            {
                Console.WriteLine("EMPATE!");
            }
        }

        public bool FimDeJogo(List<string> jogoP, List<string> jogoC)
        {
            bool jogadorTravado = JogadorTravado();
            if (linhaP.Count == 0)
            {
                Console.WriteLine("O jogador venceu a partida!");
                return true;
            }
            else if (linhaC.Count == 0)
            {
                Console.WriteLine("O computador venceu a partida!");
                return true;
            }
            else if (jogadorTravado && computadorTravado)
            {
                Console.WriteLine("Nenhum jogador possuí peças compatíveis!");
                ContarPontos(jogoP, jogoC);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
