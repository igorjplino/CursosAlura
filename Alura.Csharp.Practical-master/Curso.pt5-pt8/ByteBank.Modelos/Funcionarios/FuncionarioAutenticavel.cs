using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        AutenticadorHelper _autenticadorHelper = new AutenticadorHelper();
        public string Senha { get; set; }

        public FuncionarioAutenticavel(double salario, string cpf) 
            : base(salario, cpf)
        {

        }

        public bool Autenticar(string senha)
        {
            return _autenticadorHelper.CompararSenhas(Senha, senha);
        }
    }
}
