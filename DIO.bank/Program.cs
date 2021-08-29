using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        private static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            String opcaoUsuario = Menu();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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

                opcaoUsuario = Menu();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }
        
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }
        
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }
        
        public static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            
            Console.WriteLine("Digite o saldo inicial da conta: ");
            double saldo = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o crédito da conta: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta) tipoConta,
                saldo: saldo,
                credito: credito,
                nome: nome);
            
            listaContas.Add(novaConta);

        }

        public static void ListarContas()
        {
            int counter = 0;
            foreach (var conta in listaContas)
            {
                Console.Write("#{0} - ", counter);
                Console.WriteLine(conta);
                counter++;
            }
        }

        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}