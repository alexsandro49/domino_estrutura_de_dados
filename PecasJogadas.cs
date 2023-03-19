using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    internal class PecasJogadas
    {
        public Peca cabeca;

        public bool Inserir(string pos, Peca peca)
        {
            if (cabeca == null)
            {
                cabeca = peca;
                return true;
            }
            else
            {
                if (pos == "final")
                {
                    Peca atual = cabeca;

                    while (atual.proximo != null)
                    {
                        atual = atual.proximo;
                    }

                    if (atual.ladoB == peca.ladoA)
                    {
                        atual.proximo = peca;
                        return true;
                    }
                    else if (atual.ladoB == peca.ladoB)
                    {
                        atual.proximo = peca;
                        byte temp = peca.ladoB;
                        atual.proximo.ladoB = peca.ladoA;
                        atual.proximo.ladoA = temp;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (cabeca.ladoA == peca.ladoA)
                    {
                        Peca temp = peca;
                        temp.proximo = cabeca;
                        byte temp1 = peca.ladoA;
                        temp.ladoA = peca.ladoB;
                        temp.ladoB = temp1;
                        cabeca = temp;
                        return true;
                    }
                    else if (cabeca.ladoA == peca.ladoB)
                    {
                        Peca temp = peca;
                        temp.proximo = cabeca;
                        cabeca = temp;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool Testar(Peca peca, string pos)
        {
            if (pos == "final")
            {
                Peca atual = cabeca;

                while (atual.proximo != null)
                {
                    atual = atual.proximo;
                }

                if (atual.ladoB == peca.ladoA)
                {
                    return true;
                }
                else if (atual.ladoB == peca.ladoB)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (cabeca.ladoA == peca.ladoA)
                {
                    return true;
                }
                else if (cabeca.ladoA == peca.ladoB)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<string> Mostrar()
        {
            Peca atual = cabeca;
            List<string> lista = new List<string>();

            while (atual != null)
            {
                atual.UpdatePeca();
                lista.Add(atual.valores);
                atual = atual.proximo;
            }
            return lista;
        }
    }
}

