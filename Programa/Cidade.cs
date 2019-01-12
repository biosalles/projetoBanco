using System;
using System.Collections.Generic;
using System.Text;

namespace Programa
{
    internal class Cidade
    {
        public string Nome { get; private set; }
        public string UF { get; private set; }

        public Cidade(string nome, string uf)
        {
            Nome = nome;
            UF = uf;
        }
    }



}
