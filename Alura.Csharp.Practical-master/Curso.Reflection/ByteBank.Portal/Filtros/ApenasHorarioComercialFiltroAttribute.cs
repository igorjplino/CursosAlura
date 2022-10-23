using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Portal.Infraestrutura.Filtros;

namespace ByteBank.Portal.Filtros
{
    public class ApenasHorarioComercialFiltroAttribute : FiltroAttribute
    {
        public override bool PodeContinuar()
        {
            var hora = DateTime.Now.Hour;

            return hora >= 9 && hora < 14;
        }
    }
}
