using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos
{
    internal class AutenticadorHelper
    {
        public bool CompararSenhas(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaVerdadeira == senhaTentativa;
        }
    }
}
