using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Portal.Filtros;
using ByteBank.Portal.Infraestrutura;
using ByteBank.Portal.Model;
using ByteBank.Service;
using ByteBank.Service.Cambio;

namespace ByteBank.Portal.Controller
{
    public class CambioController : ControllerBase
    {
        private ICambioService _cambioService;
        private ICartaoService _cartaoService;

        public CambioController(ICambioService cambioService, ICartaoService cartaoService)
        {
            _cambioService = cambioService;
            _cartaoService = cartaoService;
        }

        [ApenasHorarioComercialFiltro]
        public string MXN()
        {
            var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);

            return View(new
            {
                Valor = valorFinal
            });
        }

        [ApenasHorarioComercialFiltro]
        public string USD()
        {
            var valorFinal = _cambioService.Calcular("USD", "BRL", 1);

            return View(new
            {
                Valor = valorFinal
            });
        }

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino) =>
            Calculo("BLR", moedaDestino, 1);

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino, decimal valor) =>
            Calculo("BLR", moedaDestino, valor);

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var cartaoPromocao = _cartaoService.ObterCartaoDeCreditoDeDestaque();

            var model = new
            {
                MoedaDestino = moedaDestino,
                ValorDestino = valorFinal,
                MoedaOrigem = moedaOrigem,
                ValorOrigem = valor,
                CartaoPromocao = cartaoPromocao
            };

            return View(model);
        }
    }
}
