using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos
{
    public class ParceiroComercial : IAutenticavel
    {
        AutenticadorHelper _autenticadorHelper = new AutenticadorHelper();
        public string Senha { get; set; }

        public bool Autenticar(string senha)
        {
            return _autenticadorHelper.CompararSenhas(Senha, senha);
        }
    }
}
