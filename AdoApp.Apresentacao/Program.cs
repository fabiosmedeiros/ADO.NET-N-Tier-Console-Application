using AdoApp.Dominio;
using AdoApp.Servico;
using System;
using System.Collections.Generic;

namespace AdoApp.Apresentacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool continua = false;

            do
            {
                Console.WriteLine("*** Cadastro de Clientes ***");
                Console.WriteLine("Digite o nome do cliente :");

                // O método ReadLine() é utilizado para aceitar entradas do teclado.
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o e-mail do cliente :");

                string email = Console.ReadLine();

                Console.WriteLine("Digite o telefone do cliente :");

                string telefone = Console.ReadLine();

                Console.WriteLine("Digite a data de nascimento do cliente :");

                // O método Parse() converte a string passada como parâmetro em DateTime.
                DateTime dataDeNascimento = DateTime.Parse(Console.ReadLine());
                // Criando um objeto do tipo Cliente, e atribuindo valores.
                Cliente cliente = new Cliente
                {
                    // Para testar a operação de atualização, basta descomentar e informar um Id existente.
                    //Id = 1007,
                    Nome = nome,
                    Email = email,
                    Telefone = telefone,
                    DataDeNascimento = dataDeNascimento,
                    DataDeCadastro = DateTime.Now
                };

                ClienteServico clienteServico = new ClienteServico();

                // Adicionando um cliente, utilizando o método Adicionar da classe ClienteServico.
                clienteServico.Adicionar(cliente);
                Console.Clear();
                Console.WriteLine("Lista de clientes cadastrados : ");

                // Obtendo a lista de clientes.
                List<Cliente> clientes = clienteServico.Lista();

                // Listando os clientes cadastrados.
                foreach (var umCliente in clientes)
                {
                    string dadosClientes = "";
                    dadosClientes += string.Format("Id : {0}\n" +
                                                   "Nome : {1}\n" +
                                                   "Email : {2}\n" +
                                                   "Telefone : {3}\n" +
                                                   "DataDeNascimento : {4}\n" +
                                                   "DataDeCadastro : {5}\n" +
                                                   "*********************************************\n",
                                                   umCliente.Id, 
                                                   umCliente.Nome, 
                                                   umCliente.Email, 
                                                   umCliente.Telefone,
                                                   umCliente.DataDeNascimento, 
                                                   umCliente.DataDeCadastro);

                    Console.WriteLine(dadosClientes);
                }

                Console.WriteLine("Cadastrar mais um cliente ? (Digite S ou N)");

                string resposta = Console.ReadLine();

                // Atenção para este while.
                while (!(resposta == "s" || resposta == "S" || resposta == "n" || resposta == "N"))
                {
                    Console.WriteLine("Tecla inválida. Digite apenas S ou N");

                    resposta = Console.ReadLine();
                }

                switch (resposta)
                {
                    case "s":
                        continua = true;
                        break;
                    case "S":
                        continua = true;
                        break;
                    case "n":
                        continua = false;
                        break;
                    case "N":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Tecla inválida");
                        break;
                }
            } while (continua == true);
        }
    }
}
