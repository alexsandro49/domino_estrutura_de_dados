using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    internal class PecasJogadas
    {
        private string linha1 = "---------";
        private List<string> linha21 = new List<string>();
        private List<string> linha22 = new List<string>();
        private List<string> linha23 = new List<string>();
        private List<string> linha24 = new List<string>();
        public List<string> linhaP = new List<string>();
        private List<string> linhaC = new List<string>();

        public void AtualizarJogo(string jogo, Peca peca)
        {
            if (linhaP.Count < 7)
            {
                if (jogo == "jogador")
                {
                    linhaP.Add($"{peca.valores}");
                }
                else
                {
                    linhaC.Add($"{peca.valores}");
                }
            }
        }

        public void RemoverPeca(string jogo, string valorPeca)
        {
            if (jogo == "jogador")
            {
                linhaP.Remove($"| {valorPeca.Substring(0, 1)} | {valorPeca.Substring(1, 1)} |");
            }
            else
            {
                linhaC.Remove($"| {valorPeca.Substring(0, 1)} | {valorPeca.Substring(1, 1)} |");
            }
        }
        
        public void Adicionar(Peca peca)
        {
            if (linha21.Count < 7)
            {
                linha21.Add($"{peca.valores}");
            }
            else if (linha22.Count < 7)
            {
                linha22.Add($"{peca.valores}");
            }
            else if (linha23.Count < 7)
            {
                linha23.Add($"{peca.valores}");
            }
            else if (linha24.Count < 7)
            {
                linha24.Add($"{peca.valores}");
            }
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
                x.ForEach(item => Console.Write($"{item} "));
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
            Console.WriteLine();
            LinhaPecas(linhaP, (sbyte)(pos - 1));
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
            LinhaPecas(linha21);

            if (linha22.Count > 0)
            {
                LinhaPecas(linha22);
            }

            if (linha23.Count > 0)
            {
                LinhaPecas(linha23);
            }

            if (linha24.Count > 0)
            {
                LinhaPecas(linha24);
            }
        }
    }
}
