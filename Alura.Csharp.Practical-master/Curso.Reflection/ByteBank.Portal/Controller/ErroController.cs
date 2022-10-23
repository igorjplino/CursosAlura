using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Portal.Infraestrutura;

namespace ByteBank.Portal.Controller
{
    public class ErroController : ControllerBase
    {
        public string Inesperado() => 
            View();
    }
}
