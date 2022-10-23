using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R30.ReplaceTypeCodeWStateStrategy.depois
{
    class Programa
    {
        void Main()
        {
            Funcionario funcionario1 = new Funcionario(new Engenheiro(), 2000, 0, 0);
            Funcionario funcionario2 = new Funcionario(new Vendedor(), 2000, 1500, 0);
            Funcionario funcionario3 = new Funcionario(new Gerente(), 3000, 0, 1000);

            var valorFolhaDePagamento =
                funcionario1.Salario
                + funcionario2.Salario
                + funcionario3.Salario;
        }
    }

    class Funcionario
    {
        public const int ENGENHEIRO = 0;
        public const int VENDEDOR = 1;
        public const int GERENTE = 2;

        private readonly TipoFuncionario tipo;
        public TipoFuncionario Tipo { get; }

        private readonly decimal salario;
        public decimal Salario { get; }

        private readonly decimal comissao;
        public decimal Comissao { get; }

        private readonly decimal bonus;
        public decimal Bonus { get; }

        public Funcionario(TipoFuncionario tipo, decimal salario, decimal comissao, decimal bonus)
        {
            this.tipo = tipo;
            this.salario = salario;
            this.comissao = comissao;
            this.bonus = bonus;
        }

        public decimal GetPagamento()
        {
            return tipo.GetPagamento(this);
        }
    }

    abstract class TipoFuncionario
    {
        public virtual decimal GetPagamento(Funcionario funcionario)
        {
            return funcionario.Salario;
        }
    }

    class Engenheiro : TipoFuncionario
    {

    }

    class Vendedor : TipoFuncionario
    {
        public override decimal GetPagamento(Funcionario funcionario)
        {
            return funcionario.Salario + funcionario.Comissao;
        }
    }

    class Gerente : TipoFuncionario
    {
        public override decimal GetPagamento(Funcionario funcionario)
        {
            return funcionario.Salario + funcionario.Bonus;
        }
    }
}
