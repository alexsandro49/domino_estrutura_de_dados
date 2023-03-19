using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace domino_estrutura_de_dados
{
    internal class LogicaJogo
    {
        private string linha1 = "---------";
        private PecasJogadas pecasJogadas = new PecasJogadas();

        public List<Peca> pecasJogador = new List<Peca>();
        public List<Peca> pecasComputador = new List<Peca>();

        List<string> pecasPossiveis = new List<string>() { "00", "01", "11", "02", "12", "22", "03",
            "13", "23", "33", "04", "14", "24", "34", "44", "05", "15", "25", "35", "45", "55", 
            "06", "16", "26", "36", "46", "56", "66" };
        List<string> bombas = new List<string> { "00", "11", "22", "33", "44", "55", "66" };

        Random random = new Random();
        bool computadorTravado = false;

        public List<string> NovoJogoP()
        {
            List<string> pecasP = new List<string>();
            while (pecasP.Count < 7)
            {
                Random random = new Random();
                string peca = pecasPossiveis[random.Next(0, 28)];
                if (!pecasP.Contains(peca))
                {
                    pecasP.Add(peca);
                }
            }
            return pecasP;
        }

        public List<string> NovoJogoC(List<string> pecasP)
        {
            List<string> pecasC = new List<string>();
            while (pecasC.Count < 7)
            {
                Random random = new Random();
                string peca = pecasPossiveis[random.Next(0, 28)];
                if (!pecasP.Contains(peca) && !pecasC.Contains(peca))
                {
                    pecasC.Add(peca);
                }
            }
            return pecasC;
        }
        public void AdicionarPeca(string jogo, Peca peca)
        {
            if (jogo == "jogador")
            {
                if (pecasJogador.Count < 7)
                {
                    pecasJogador.Add(peca);
                }
            }
            else
            {
                if (pecasComputador.Count < 7)
                {
                    pecasComputador.Add(peca);
                }
            }
        }

        public void RemoverPeca(string jogo, Peca peca)
        {
            if (jogo == "jogador")
            {
                pecasJogador.Remove(peca);
            }
            else
            {
                pecasComputador.Remove(peca);
            }
        }

        public bool JogarPeca(string opcao, Peca peca)
        {
            bool validade = pecasJogadas.Inserir(opcao, peca);
            return validade;
        }

        public void InicioJogo(List<string> jogoP, List<string> jogoC)
        {
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
            Peca pecaRemovida = pecasJogador[0];

            void InicioJogoLocal(string opcao)
            {
                List<Peca> opcPecas;
                List<string> bombas;
                if (opcao == "jogador")
                {
                    opcPecas = pecasJogador;
                    bombas = bombasP;
                }
                else
                {
                    opcPecas = pecasComputador;
                    bombas = bombasC;
                }

                Console.Write($"O {opcao} inicia com a peca: ");
                Console.ForegroundColor = ConsoleColor.Red;
                string ladoA = bombas[bombas.Count - 1].Substring(0, 1);
                string ladoB = bombas[bombas.Count - 1].Substring(1, 1);
                foreach (var item in opcPecas)
                {
                    if (item.valores == $"| {ladoA} | {ladoB} |")
                    {
                        Console.WriteLine(item.valores);
                        Console.ResetColor();
                        validade = JogarPeca("inicio", item);
                        pecaRemovida = item;
                        break;
                    }
                }
                if (validade)
                {
                    RemoverPeca(opcao, pecaRemovida);
                    if (opcao == "jogador")
                    {
                        JogadaComputador();
                    }
                }
            }

            if (bombasP.Count > 0 && bombasC.Count > 0)
            {
                if (byte.Parse(bombasP[bombasP.Count - 1]) > byte.Parse(bombasC[bombasC.Count - 1]))
                {
                    InicioJogoLocal("jogador");
                }
                else
                {
                    InicioJogoLocal("computador");
                }
            }
            else if (bombasP.Count > 0)
            {
                InicioJogoLocal("jogador");
            }
            else if (bombasC.Count > 0)
            {
                InicioJogoLocal("computador");
            }
            else
            {
                byte maiorP = byte.Parse(jogoP[jogoP.Count - 1]);
                byte maiorC = byte.Parse(jogoC[jogoC.Count - 1]);
                if (maiorP > maiorC)
                {
                    InicioJogoLocal("jogador");
                }
                else
                {
                    InicioJogoLocal("computador");
                }
            }
        }
        
        public void JogadaComputador()
        {
            List<Peca> pecasPossiveisComputador = new List<Peca>();
            bool validade = true;

            foreach (var item in pecasComputador)
            {
                if (pecasJogadas.Testar(item, "inicio") || pecasJogadas.Testar(item, "final"))
                {
                    pecasPossiveisComputador.Add(item);
                }
            }

            if (pecasPossiveisComputador.Count > 0)
            {
                Peca pecaAleatoria = pecasPossiveisComputador[random.Next(pecasPossiveisComputador.Count)];
                validade = JogarPeca("inicio", pecaAleatoria);
                string pos = "início";
                if (!validade)
                {
                    JogarPeca("final", pecaAleatoria);
                    pos = "final";
                }
                RemoverPeca("computador", pecaAleatoria);
                Console.Write("\nO computador jogou: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{pecaAleatoria.valores} ");
                Console.ResetColor();
                Console.WriteLine($"no {pos}");
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

            foreach (var item in pecasJogador)
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

        public void ContarPontos()
        {
            int somaP = 0, somaC = 0;

            foreach (var item in pecasJogador)
            {
                somaP += (item.ladoA + item.ladoB);
            }

            foreach (var item in pecasComputador)
            {
                somaC += (item.ladoA + item.ladoB);
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

        public bool FimDeJogo()
        {
            bool jogadorTravado = JogadorTravado();
            if (pecasJogador.Count == 0)
            {
                Console.WriteLine("O jogador venceu a partida!");
                return true;
            }
            else if (pecasComputador.Count == 0)
            {
                Console.WriteLine("O computador venceu a partida!");
                return true;
            }
            else if (jogadorTravado && computadorTravado)
            {
                Console.WriteLine("Nenhum jogador possuí peças compatíveis!");
                ContarPontos();
                return true;
            }
            else
            {
                return false;
            }
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

        public void DesenharPecas(List<string> x, sbyte pos = -1)
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
            foreach (var item in pecasJogador)
            {
                lista.Add(item.valores);
            }

            if (pecasJogadas.cabeca == null)
            {
                return "1";
            }

            Console.WriteLine();
            DesenharPecas(lista, (sbyte)(pos - 1));
            Console.WriteLine();
            Console.WriteLine("1 - PEÇA NO INÍCIO ");
            Console.WriteLine("2 - PEÇA NO FINAL");
            Console.WriteLine("0 - CANCELAR");
            Console.Write(": ");
            string opc1 = Console.ReadLine();
            return opc1;
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
    }
}
