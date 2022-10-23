using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            // Ocorre erro se obj for outro tipo de Object
            //var outroCliente = (Cliente)obj;

            var outroCliente = obj as Cliente;

            if (obj == null)
            {
                return false;
            }

            return CPF == outroCliente.CPF;
        }
    }
}
