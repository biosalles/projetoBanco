using System;
using System.Collections.Generic;
using System.Text;

namespace Programa
{
    internal class Endereco
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public short Numero { get; private set; }
        public Cidade Cidade { get; private set; }

        public Endereco(string logradouro, string bairro, string cep, short numero, Cidade cidade)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Numero = numero;
            Cidade = cidade;
        }

        
    }
}
