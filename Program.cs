﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace domino_estrutura_de_dados
{
    class Program
    {
        class Peca
        {
            public byte ladoA = 0;
            public byte ladoB = 0;
            public string valores;

            public Peca(byte ladoA, byte ladoB)
            {
                this.ladoA = ladoA;
                this.ladoB = ladoB;
                this.valores = ($"| {ladoA} | {ladoB} |");
            }
        }

        class PecasJogadas
        {
            public string linha1 = "---------";
            public List<string> linha21 = new List<string>();
            public List<string> linha22 = new List<string>();
            public List<string> linha23 = new List<string>();
            public List<string> linha24 = new List<string>();

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
            public void Mostrar()
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

        static List<string> pecas = new List<string>() { "00", "01", "11", "02", "12", "22", "03", "13", "23", "33", "04", "14", "24", "34", "44", "05", "15", "25", "35", "45", "55", "06", "16", "26", "36", "46", "56", "66" };
        static void Main(string[] args)
        {
            // PecasJogadas mesa = new PecasJogadas();
            // Peca peca1 = new Peca(2, 2);
            // mesa.Adicionar(peca1);

            //gerar os jogos
            List<string> j1 = NovoJogoP();
            j1.ForEach(item => Console.WriteLine(item));
            Console.WriteLine();

            List<string> j2 = NovoJogoC(j1);
            j2.ForEach(item => Console.WriteLine(item));
            Console.WriteLine();



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