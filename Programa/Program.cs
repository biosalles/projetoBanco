using System;

namespace Programa
{
    class Program
    {
        private static readonly Banco banco = new Banco();
        private static readonly Conta contaDestino;

        static Program()
        {
            var cidade = new Cidade("Toronto", "ON");
            var endereco = new Endereco("University street", "downtown", "13219-000", 100, cidade);
            var cliente = new Cliente("Grillo", "1245667412342453", new DateTime(1985, 7, 1), endereco);
            contaDestino = banco.AbrirConta(cliente);
        }

        static void Main(string[] args)
        {
            try
            {

                var cidade = new Cidade("Vancouver", "BC");
                var endereco = new Endereco("University street", "downtown", "13219-000", 100, cidade);
                var cliente = new Cliente("Grillo", "1245667412342453", new DateTime(1985, 7, 1), endereco);
                var contaRicardo = banco.AbrirConta(cliente);
                contaRicardo.Depositar(2500);
                contaRicardo.Sacar(250);
                contaRicardo.TirarExtrato();
                contaRicardo.Transferir(1, 1, 1800);
                contaRicardo.TirarExtrato();
                contaDestino.TirarExtrato();
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            Console.ResetColor();
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Aperte uma tecla para sair");
            Console.ReadKey();
        }
    }
}
