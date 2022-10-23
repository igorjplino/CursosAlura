using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace refatoracao.R23.ChangeValueToReference.antes
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
    }

    class Projeto
    {
        private Funcionario gerente;
        internal Funcionario Gerente { get => gerente; }

        public Projeto(String nomeGerente)
        {
            this.gerente = new Funcionario(nomeGerente);
        }

        public void SetGerente(string nomeFuncionario)
        {
            this.gerente = new Funcionario(nomeFuncionario);
        }
    }
}
