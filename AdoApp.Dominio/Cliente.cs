using System;

namespace AdoApp.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public DateTime DataDeCadastro { get; set; }
    }
}
