using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    internal class PecasJogadas
    {
        public string linha1 = "---------";
        public List<string> linha21 = new List<string>();
        public List<string> linha22 = new List<string>();
        public List<string> linha23 = new List<string>();
        public List<string> linha24 = new List<string>();
        public List<string> linhaP = new List<string>();
        public List<string> linhaC = new List<string>();

        public void AtualizarJogoP(Peca peca)
        {
            if (linhaP.Count < 7)
            {
                linhaP.Add($"{peca.valores}");
            }
        }

        public void AtualizarJogoC(Peca peca)
        {
            if (linhaC.Count < 7)
            {
                linhaC.Add($"{peca.valores}");
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

        public void Linhas(int x)
        {
            for (byte i = 0; i < x; i++)
            {
                Console.Write($"{linha1} ");
            }

        }

        public void LinhaPecas(List<string> x)
        {
            Linhas(x.Count);
            Console.WriteLine();
            x.ForEach(item => Console.Write($"{item} "));
            Console.WriteLine();
            Linhas(x.Count);
            Console.WriteLine();
        }

        public void PecasJogador()
        {
            LinhaPecas(linhaP);
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
