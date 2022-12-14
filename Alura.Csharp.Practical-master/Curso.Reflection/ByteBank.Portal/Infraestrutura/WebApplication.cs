using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Portal.Controller;
using ByteBank.Portal.Infraestrutura.IoC;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
using static ByteBank.Portal.Infraestrutura.Utilidades;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        public string[] Prefixos { get; }
        private readonly IContainer _container = new ContainerSimples();

        public WebApplication(string[] prefixos)
        {
            Prefixos = prefixos ?? throw new ArgumentNullException(nameof(prefixos));

            Configurar();
        }

        public void Configurar()
        {
            //_container.Registrar(typeof(ICambioService), typeof(CambioTesteService));
            //_container.Registrar(typeof(ICartaoService), typeof(CartaoServiceTeste));

            _container.Registrar<ICambioService, CambioTesteService>();
            _container.Registrar<ICartaoService, CartaoServiceTeste>();
        }

        public void Iniciar()
        {
            while (true)
                ManipularRequisicao();
        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in Prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var path = requisicao.Url.PathAndQuery;

            if (EhArquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(resposta, path);
            }
            else
            {
                var manipulador = new ManipuladorRequisicaoController(_container);
                manipulador.Manipular(resposta, path);
            }

            httpListener.Stop();
        }
    }
}
