using System;
namespace Dio.Bank

{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}

        private double Saldo { get; set;}

        private double Credito { get; set;}

        private string Nome { get; set;}

        public Conta (TipoConta TipoConta , double Saldo , double Credito , string Nome )
        {

            this.TipoConta = TipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;

        }

        public bool SacarDinheiro(double valorDoSaque)
        {
            if (this.Saldo - valorDoSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorDoSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar (double valorDepositado)
        {
            this.Saldo += valorDepositado;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome , this.Saldo );
        }

        public void TransferirDinheiro (double ValorDaTransferencia, Conta ContaDestinoDaTransferencia)
        {
            if (this.SacarDinheiro(ValorDaTransferencia)){
                ContaDestinoDaTransferencia.Depositar(ValorDaTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito + " | ";
            return retorno;
        }
    }
}
