using AdoApp.Dominio;
using AdoApp.Repositorio;
using System.Collections.Generic;

namespace AdoApp.Servico
{
    public class ClienteServico
    {
        private readonly ClienteRepository clienteRepository = new ClienteRepository();
        
        public void Adicionar(Cliente cliente)
        {
            // Aqui podemos implementar regras de negócio para validar os dados do cliente.
            if (cliente != null)
            {
                clienteRepository.Salvar(cliente);
            }
        }

        public void Atualizar(Cliente cliente)
        {
            // Aqui podemos implementar regras de negócio para validar os dados do cliente.
            if (cliente != null)
            {
                clienteRepository.Salvar(cliente);
            }
        }

        public List<Cliente> Lista()
        {
            return clienteRepository.ListaTodos();
        }
    }
}
