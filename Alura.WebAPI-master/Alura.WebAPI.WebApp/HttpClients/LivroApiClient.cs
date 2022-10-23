using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.WebAPI.WebApp.HttpClients
{
    public class LivroApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public LivroApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            this._accessor = accessor;
        }

        public async Task<Lista> GetListLeitura(TipoListaLeitura tipo)
        {
            AddBearerToken();
            var resposta = await _httpClient.GetAsync($"listasleitura/{tipo}");
            resposta.EnsureSuccessStatusCode();

            return await resposta.Content.ReadAsAsync<Lista>();
        }

        public async Task DeleteLivroAsync(int id)
        {
            AddBearerToken();
            var resposta = await _httpClient.DeleteAsync($"livros/{id}");
            resposta.EnsureSuccessStatusCode();
        }

        public async Task<byte[]> GetCapaLivroAsync(int id)
        {
            AddBearerToken();
            var resposta = await _httpClient.GetAsync($"livros/{id}/capa");

            resposta.EnsureSuccessStatusCode();

            return await resposta.Content.ReadAsByteArrayAsync();
        }

        public async Task<LivroApi> GetLivroAsync(int id)
        {
            AddBearerToken();
            var resposta = await _httpClient.GetAsync($"livros/{id}");

            resposta.EnsureSuccessStatusCode();

            return await resposta.Content.ReadAsAsync<LivroApi>();
        }

        public async Task PostLivroAsync(LivroUpload model)
        {
            AddBearerToken();
            HttpContent content = CreateMultipartFormDataContent(model);

            var resposta = await _httpClient.PostAsync("livros", content);
            resposta.EnsureSuccessStatusCode();
        }

        public async Task PutLivroAsync(LivroUpload model)
        {
            AddBearerToken();
            HttpContent content = CreateMultipartFormDataContent(model);

            var resposta = await _httpClient.PutAsync("livros", content);
            resposta.EnsureSuccessStatusCode();
        }

        private void AddBearerToken()
        {
            var token = _accessor.HttpContext.User.Claims.First(o => o.Type == "Token").Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private HttpContent CreateMultipartFormDataContent(LivroUpload model)
        {
            var content = new MultipartFormDataContent();

            if (PodeStringContent(model.Titulo, out StringContent stringContent))
            {
                content.Add(stringContent, EnvolverAspasDuplas("titulo"));
            }

            if (PodeStringContent(model.Subtitulo, out stringContent))
            {
                content.Add(stringContent, EnvolverAspasDuplas("subtitulo"));
            }

            if (PodeStringContent(model.Resumo, out stringContent))
            {
                content.Add(stringContent, EnvolverAspasDuplas("resumo"));
            }

            if (PodeStringContent(model.Autor, out stringContent))
            {
                content.Add(stringContent, EnvolverAspasDuplas("autor"));
            }

            if (PodeStringContent(model.Lista.ParaString(), out stringContent))
            {
                content.Add(stringContent, EnvolverAspasDuplas("lista"));
            }

            if (model.Id > 0)
            {
                content.Add(new StringContent(model.Id.ToString()), EnvolverAspasDuplas("id"));
            }

            if (model.Capa != null)
            {
                var imagemContent = new ByteArrayContent(model.Capa.ConvertToBytes());
                imagemContent.Headers.Add("content-type", "image/png");
                content.Add(
                    imagemContent, 
                    EnvolverAspasDuplas("capa"), 
                    EnvolverAspasDuplas("capa.png"));
            }

            return content;
        }

        private bool PodeStringContent(string valor, out StringContent stringContent)
        {
            stringContent = null;

            if (string.IsNullOrEmpty(valor))
            {
                return false;
            }

            stringContent = new StringContent(valor);
            
            return true;
        }

        private string EnvolverAspasDuplas(string valor)
        {
            return $"\"{valor}\"";
        }
    }
}
