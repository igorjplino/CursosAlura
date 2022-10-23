using CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public interface IRelatorioHelper
    {
        Task GerarRelatorio(Pedido pedido);
    }

    public class RelatorioHelper : IRelatorioHelper
    {
        private const string RelativeUri = "/api/relatorio";
        private readonly IConfiguration configuration;

        /// Problema: não detecta mudanças no DNS. Se houver mudança, as requisições não vão mais funcionar
        //private static HttpClient httpClient;

        private readonly HttpClient httpClient;

        public RelatorioHelper(IConfiguration configuration, HttpClient httpClient)
        {
            this.configuration = configuration;
            this.httpClient = httpClient;
        }

        public async Task GerarRelatorio(Pedido pedido)
        {
            string linhaRelatorio = await GetLinhaRelatorio(pedido);

            /// Problema: exaustão de socket.
            /// Foi descoberto na comunidade que IDisposeble do HttpClient não liberava corretamente todos os recursos.
            /// Depois de algum tempo de execução da aplicação, não terá mais sockets disponíves para comunicação
            //using (var httpClient = new HttpClient())

            /// Esta é uma forma de resolver os problemas de sockets.
            /// Outra forma, é por injeção de dependencia no construtor
            //using (var httpClient = HttpClientFactory.Create())
            //{

            //}

            var json = JsonConvert.SerializeObject(linhaRelatorio);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var baseUri = new Uri(configuration["RelatorioWebAPIURL"]);
            var uri = new Uri(baseUri, RelativeUri);

            var response = await httpClient.PostAsync(uri, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
        }

        private async Task<string> GetLinhaRelatorio(Pedido pedido)
        {
            StringBuilder sb = new StringBuilder();
            string templatePedido =
                    await System.IO.File.ReadAllTextAsync("TemplatePedido.txt");

            string templateItemPedido =
                await System.IO.File.ReadAllTextAsync("TemplateItemPedido.txt");

            string linhaPedido =
                string.Format(templatePedido,
                    pedido.Id,
                    pedido.Cadastro.Nome,
                    pedido.Cadastro.Endereco,
                    pedido.Cadastro.Complemento,
                    pedido.Cadastro.Bairro,
                    pedido.Cadastro.Municipio,
                    pedido.Cadastro.UF,
                    pedido.Cadastro.Telefone,
                    pedido.Cadastro.Email,
                    pedido.Itens.Sum(i => i.Subtotal));

            sb.AppendLine(linhaPedido);

            foreach (var i in pedido.Itens)
            {
                string linhaItemPedido =
                    string.Format(
                        templateItemPedido,
                        i.Produto.Codigo,
                        i.PrecoUnitario,
                        i.Produto.Nome,
                        i.Quantidade,
                        i.Subtotal);

                sb.AppendLine(linhaItemPedido);
            }
            sb.AppendLine($@"=============================================");

            return sb.ToString();
        }
    }
}