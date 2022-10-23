using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }
        
        public static int TotalFuncionarios { get; set; }

        public Funcionario(double salario, string cpf)
        {
            CPF = cpf;
            Salario = salario;

            TotalFuncionarios++;
        }

        public abstract void AumentarSalario();

        internal protected abstract double GetBonificacao();
    }
}
