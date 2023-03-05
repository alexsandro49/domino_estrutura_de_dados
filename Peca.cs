using System;
using System.Collections.Generic;

namespace domino_estrutura_de_dados
{
    internal class Peca
    {
        private byte ladoA = 0;
        private byte ladoB = 0;
        public string valores;

        public Peca(string x)
        {
            this.ladoA = Convert.ToByte(x.Substring(0, 1));
            this.ladoB = Convert.ToByte(x.Substring(1, 1));
            this.valores = ($"| {ladoA} | {ladoB} |");
        }
    }
}
