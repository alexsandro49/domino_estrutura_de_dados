using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace domino_estrutura_de_dados
{
    internal class LogicaJogo
    {
        private string linha1 = "---------";
        private PecasJogadas pecasJogadas = new PecasJogadas();

        public List<Peca> linhaP = new List<Peca>();
        public List<Peca> linhaC = new List<Peca>();

        public void AtualizarJogo(string jogo, Peca peca)
        {
            if (linhaP.Count < 7)
            {
                if (jogo == "jogador")
                {
                    linhaP.Add(peca);
                }
                else
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
        
        public bool JogarPeca(Peca peca, string opcao)
        {
            bool validade = pecasJogadas.Inserir(peca, opcao);
            return validade;
        }
        
        public void Linhas(int x, int y = -1)
        {
            for (int i = 0; i < x; i++)
            {
                if (y > -1 && i == y)
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
                    Console.Write($"{x[pos]} ");
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
            LinhaPecas(pecasJogadas.Mostrar());
        }
    }
}
