using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R35.RemoveControlFlag.antes
{
    class Programa
    {
        void Main()
        {
            var gerenciador =
                new GerenciadorPessoas()
                .EncontrarPessoaEspecial(new List<string> {
                    "Marcelo",
                    "Marcos",
                    "Diego",
                    "Caio",
                    "Marlon" });
        }
    }

    class GerenciadorPessoas
    {
        public bool EncontrarPessoaEspecial(IList<string> pessoas)
        {
            bool encontrouPessoa = false;
            foreach (var pessoa in pessoas)
            {
                if (pessoa.Equals("Diego"))
                {
                    EnviarAlerta();
                    encontrouPessoa = true;
                }
                if (pessoa.Equals("João"))
                {
                    EnviarAlerta();
                    encontrouPessoa = true;
                }
            }
            return encontrouPessoa;
        }

        private static void EnviarAlerta()
        {
            //código para enviar um alerta
        }
    }

}
