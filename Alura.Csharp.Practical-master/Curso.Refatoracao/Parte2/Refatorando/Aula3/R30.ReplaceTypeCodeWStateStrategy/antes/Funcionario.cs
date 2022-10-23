using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R30.ReplaceTypeCodeWStateStrategy.antes
{
    class Programa
    {
        void Main()
        {
            Funcionario funcionario1 = Funcionario.Criar(Funcionario.ENGENHEIRO, 2000, 0, 0);
            Funcionario funcionario2 = Funcionario.Criar(Funcionario.VENDEDOR, 2000, 1500, 0);
            Funcionario funcionario3 = Funcionario.Criar(Funcionario.GERENTE, 3000, 0, 1000);

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

        private readonly int tipo;
        public int Tipo { get; }

        private readonly decimal salario;
        public decimal Salario { get; }

        private readonly decimal comissao;
        public decimal Comissao { get; }

        private readonly decimal bonus;
        public decimal Bonus { get; }

        private Funcionario(int tipo, decimal salario, decimal comissao, decimal bonus)
        {
            this.tipo = tipo;
            this.salario = salario;
            this.comissao = comissao;
            this.bonus = bonus;
        }

        public decimal GetPagamento()
        {
            switch (Tipo)
            {
                case ENGENHEIRO:
                    return Salario;
                case VENDEDOR:
                    return Salario + Comissao;
                case GERENTE:
                    return Salario + Bonus;
                default:
                    break;
            }
            throw new Exception("Tipo desconhecido");
        }

        public static Funcionario Criar(int tipo, decimal salario, decimal comissao, decimal bonus)
        {
            return new Funcionario(tipo, salario, comissao, bonus);
        }
    }


}
