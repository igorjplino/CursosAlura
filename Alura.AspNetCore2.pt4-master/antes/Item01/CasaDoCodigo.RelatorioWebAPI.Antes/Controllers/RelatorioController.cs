using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CasaDoCodigo.RelatorioWebAPI.Antes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private static readonly List<string> Relatorio = new List<string>()
        {
            "Primeiro pedido",
            "Seguindo pedido"
        };

        // GET: api/<RelatorioController>
        [HttpGet]
        public string Get()
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in Relatorio)
            {
                stringBuilder.AppendLine(item);
            }

            return stringBuilder.ToString();
        }

        // POST api/<RelatorioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Relatorio.Add(value);
        }
    }
}
