using Alura.ListaLeitura.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alura.WebAPI.WebApp.HttpClients
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
    }

    public class AuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResult> PostLoginASync(LoginModel model)
        {
            var resposta = await _httpClient.PostAsJsonAsync("login", model);

            return new LoginResult
            {
                Succeeded = resposta.IsSuccessStatusCode,
                Token = await resposta.Content.ReadAsStringAsync()
            };
        }
    }
}
