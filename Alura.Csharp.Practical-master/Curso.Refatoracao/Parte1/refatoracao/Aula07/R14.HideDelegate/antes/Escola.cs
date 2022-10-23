using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R14.HideDelegate.antes
{
    class Escola
    {
        public string Nome { get; private set; }
        public Funcionario Diretor { get; private set; }
    }

    class Departamento
    {
        public Escola Escola { get; private set; }
    }

    class Funcionario
    {
        public Departamento Departamento { get; private set; }
    }

    class Teste
    {
        public Teste()
        {
            var maria = new Funcionario();
            var diretorDaMaria = maria.Departamento.Escola.Diretor;
        }
    }
}
