using System;
using System.Collections.Generic;
using System.Text;
using Programa.Enuns;

namespace Programa
{
    internal class Transacao
    {
        public TipoTransacao TipoTransacao { get; private set; }
        public string  Descricao { get; private set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; private set; }

        public Transacao(string descricao, decimal valor, TipoTransacao tipoTransacao)
        {
            Descricao = descricao;
            Valor = valor;
            TipoTransacao = tipoTransacao;
            DataHora = DateTime.Now;
        }
    }
}
