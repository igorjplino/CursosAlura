using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R29.ReplaceTypeCodeWithSubclasses.depois
{
    class Programa
    {
        void Main()
        {
            Funcionario engenheiro = new Engenheiro("José da Silva", 1000);
            Funcionario vendedor = new Vendedor("Maria Bonita", 2000);
            Funcionario gerente = new Gerente("João das Neves", 3000);

            var valorFolhaDePagamento =
                engenheiro.Salario
                + vendedor.Salario
                + gerente.Salario;
        }
    }

    abstract class Funcionario
    {
        public enum TipoFuncionario
        {
            Engenheiro = 0,
            Vendedor = 1,
            Gerente = 2
        }

        protected TipoFuncionario tipo;
        public TipoFuncionario Tipo { get; }

        readonly string nome;
        public string Nome => nome;

        readonly decimal salario;
        public decimal Salario => salario;

        public abstract decimal Comissao { get; }

        public abstract decimal Bonus { get; }

        public Funcionario(string nome, decimal salario)
        {
            this.nome = nome;
            this.salario = salario;
        }
    }

    class Engenheiro : Funcionario
    {
        public Engenheiro(string nome, decimal salario) : base(nome, salario)
        {
            tipo = TipoFuncionario.Engenheiro;
        }

        public override decimal Comissao => 0;

        public override decimal Bonus => 0;
    }

    class Vendedor : Funcionario
    {
        public Vendedor(string nome, decimal salario) : base(nome, salario)
        {
            tipo = TipoFuncionario.Vendedor;
        }

        public override decimal Comissao => 1000;

        public override decimal Bonus => 0;
    }

    class Gerente : Funcionario
    {
        public Gerente(string nome, decimal salario) : base(nome, salario)
        {
            tipo = TipoFuncionario.Gerente;
        }

        public override decimal Comissao => 0;

        public override decimal Bonus => Salario / 2.0m;
    }
}
