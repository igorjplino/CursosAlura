using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace refatoracao.R23.ChangeValueToReference.depois
{
    class Programa
    {
        void Main()
        {
            var projeto = new Projeto("João Snow");
            projeto.SetGerente("Sonia Stark");
        }

        private static int QtdePedidosDe(IList<Projeto> orders, string nomeCliente)
        {
            return orders.Count(o => o.Gerente.Nome == nomeCliente);
        }
    }

    class Funcionario
    {
        private readonly String nome;
        public string Nome => nome;

        public Funcionario(String name)
        {
            this.nome = name;
        }

        public override bool Equals(object obj)
        {
            Funcionario outro = obj as Funcionario;
            if (outro == null)
            {
                return false; //early return
            }
            return base.Equals(outro);
        }

        public override int GetHashCode()
        {
            return nome.GetHashCode();
        }

        private static IDictionary<string, Funcionario> funcionarios
            = new Dictionary<string, Funcionario>();

        internal static Funcionario Get(string nome)
        {
            Funcionario funcionario = funcionarios[nome];

            if (funcionario == null)
            {
                funcionario = new Funcionario(nome);
                funcionarios.Add(nome, funcionario);
            }

            return funcionario;
        }
    }

    class Projeto
    {
        private Funcionario gerente;
        internal Funcionario Gerente { get => gerente; }

        public Projeto(String nomeGerente)
        {
            this.gerente = Funcionario.Get(nomeGerente);
        }

        public void SetGerente(string nomeFuncionario)
        {
            this.gerente = Funcionario.Get(nomeFuncionario);
        }
    }
}
