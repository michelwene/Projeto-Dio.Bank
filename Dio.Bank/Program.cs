using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            {
                string OpcaoUsuario = ObterOpcaoUsuario();

                while(OpcaoUsuario.ToUpper() != "X")
                {
                    switch(OpcaoUsuario)
                    {
                        case "1":
                            ListarContas();
                            break;
                        case "2":
                            InserirConta();
                            break;
                        case "3":
                            Transferir();
                            break;
                        case "4":
                            Sacar();
                            break;
                        case "5":
                            Depositar();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    OpcaoUsuario = ObterOpcaoUsuario();
                }
                Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
            }

          Conta  minhaConta = new Conta (TipoConta.PessoaFisica , 0 , 0 , "Michel Wene");
          Console.WriteLine(minhaConta.ToString());
        }

        private static void Transferir()
            {
                Console.Write("Digite o número da conta de origem: ");
                int indiceContaOrigem = int.Parse(Console.ReadLine());

                Console.Write("Digite o número da conta de destino: ");
                int indiceContaDestino = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser transferido: ");
                double ValorDaTransferencia = double.Parse(Console.ReadLine());

                listContas[indiceContaOrigem].TransferirDinheiro(ValorDaTransferencia, listContas[indiceContaDestino]);

            }

        private static void Sacar()
            {
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser sacado: ");
                double valorDoSaque = double.Parse(Console.ReadLine());

                listContas[indiceConta].SacarDinheiro(valorDoSaque);

            }
            private static void Depositar()
            {
                Console.Write("Digite o número da conta: ");
                int indiceConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor a ser depositado: ");
                double valorDepositado = double.Parse(Console.ReadLine());

                listContas[indiceConta].Depositar(valorDepositado);

            }


        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(TipoConta: (TipoConta)entradaTipoConta,
                                                    Saldo: entradaSaldo, 
                                                    Credito: entradaCredito,
                                                    Nome: entradaNome);

            listContas.Add(novaConta);
         }
         private static void ListarContas()
         {
             Console.WriteLine("Listar contas");

             if (listContas.Count == 0)
             {
                 Console.WriteLine("Nenhuma conta cadastrada.");
                 return;
             }
             for (int i = 0; i < listContas.Count; i++)
             {
                 Conta conta = listContas[i];
                 Console.Write("#{0} - ", i);
                 Console.WriteLine(conta);
             }
         }

        private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("DIO Bank a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada");
                Console.WriteLine("1- Listar contas");
                Console.WriteLine("2- Inserir nova conta");
                Console.WriteLine("3- Transferir ");
                Console.WriteLine("4- Sacar ");
                Console.WriteLine("5- Depositar");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string OpcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return OpcaoUsuario;
            }
    }
}
