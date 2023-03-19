using System;

namespace domino_estrutura_de_dados
{
    internal class Peca
    {
        public byte ladoA, ladoB;
        public Peca proximo;
        public string valores;

        public Peca(string x)
        {
            this.ladoA = Convert.ToByte(x.Substring(0, 1));
            this.ladoB = Convert.ToByte(x.Substring(1, 1));
            this.valores = ($"| {ladoA} | {ladoB} |");
        }

        public void UpdatePeca()
        {
            this.valores = ($"| {ladoA} | {ladoB} |");
        }
    }
}
