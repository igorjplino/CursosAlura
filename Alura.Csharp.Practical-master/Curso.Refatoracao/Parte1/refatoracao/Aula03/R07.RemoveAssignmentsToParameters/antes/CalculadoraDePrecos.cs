using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R07.RemoveAssignmentsToParameters.antes
{
    class CalculadoraDePrecos
    {
        decimal GetDescontoFinal(decimal descontoInicial, int quantidade, int clienteHaQuantosAnos)
        {
            if (descontoInicial > 50M)
            {
                descontoInicial = 50M;
            }
            if (quantidade > 100)
            {
                descontoInicial += 15M;
            }
            if (clienteHaQuantosAnos > 4)
            {
                descontoInicial += 10M;
            }
            return descontoInicial;
        }
    }
}


