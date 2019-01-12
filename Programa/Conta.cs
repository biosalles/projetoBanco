using System;
using System.Collections.Generic;
using System.Text;
using Programa.Enuns;

namespace Programa
{
    internal class Conta
    {
       public TipoConta TipoConta { get; private set; }
       public int Agencia { get; private set; }
       public int Numero { get; private set; }
       public decimal Saldo { get; private set; }
       public Banco Banco { get; private set; }

       public List<Transacao> Transacoes { get; private set; }

       public Conta(TipoConta tipoConta, int agencia, int numero, Banco banco)
        {
            TipoConta = tipoConta;
            Agencia = agencia;
            Numero = numero;
            Banco = banco;
            Transacoes = new List<Transacao>();
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor solicitado é invalido");
            if (valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar o saque.");
            Debitar("Retirada", valor);
            Console.WriteLine("Saque bem sucedido");


        }
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor solicitado é invalido");

            Creditar("Deposito", valor);
            Console.WriteLine("Deposito bem sucedido");
        }
        public void Transferir(int agencia, int numeroConta, decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor solicitado é invalido");
            if (valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar a transferencia.");

            Conta contaDestino = Banco.ObterConta(agencia, numeroConta);
            contaDestino.Creditar("Transferencia", valor);
            Debitar("Transferencia", valor);
        }
        public void TirarExtrato()
        {
            if(Transacoes.Count > 0)
            {
                foreach(var transacao in Transacoes)
                {
                    var cor = transacao.TipoTransacao == TipoTransacao.Debito ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.ForegroundColor = cor;
                    var desr = transacao.Descricao.PadRight(20, '-') + transacao.Valor.ToString("C");
                    Console.WriteLine(desr);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(string.Empty);
                var saldoDescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(saldoDescricao);
            }
        }

        private void Creditar (string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Credito);
            Transacoes.Add(transacao);
            Saldo = Saldo + valor;
        }

        private void Debitar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Debito);
            Transacoes.Add(transacao);
            Saldo = Saldo - valor;
        }
    }
}
