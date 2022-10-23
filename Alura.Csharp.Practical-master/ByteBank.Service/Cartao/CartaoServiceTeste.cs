using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Service.Cartao
{
    public class CartaoServiceTeste : ICartaoService
    {
        public string ObterCartaoDeCreditoDeDestaque() =>
            "Cartão especial muito bom";

        public string ObterCartaoDeDebitoDeDestaque() =>
            "Cartão para estudando que não é tão bom";
    }
}
