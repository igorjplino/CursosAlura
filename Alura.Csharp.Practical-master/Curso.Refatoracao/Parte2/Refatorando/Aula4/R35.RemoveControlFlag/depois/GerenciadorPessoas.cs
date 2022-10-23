using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R35.RemoveControlFlag.depois
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
            var pessoasEspeciais = new List<string> { "Diego", "João" };

            foreach (var pessoa in pessoas)
            {
                if (pessoasEspeciais.Contains(pessoa))
                {
                    EnviarAlerta();
                    return true;
                }
            }
            return false;
        }

        private static void EnviarAlerta()
        {
            //código para enviar um alerta
        }
    }

}
