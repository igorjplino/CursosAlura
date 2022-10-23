using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private ApplicationContext contexto { get; }
        private IProdutoRepository produtoRepository { get; }

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            /// EnsureCreated garante a criação do banco de dados caso não exista.
            /// Mas, ele não cria utilizando os arquivos de Migrations e nem permite que os utilize depois no seu banco.
            /// É recomendando utilizar somente em aplicações pequenas ou para testes de código
            //serviceProvider.GetService<ApplicationContext>().Database.EnsureCreated();

            /// Migrate tem a mesma função do EnsureCreated, mas utiliza os arquivos de Migrations
            /// na criação do banco de dados e permite que adicione novas migrações, caso necessário.
            contexto.Database.Migrate();
            
            var livros = GetLivros();
            produtoRepository.SaveProdutos(livros);
        }

        private List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);

            return livros;
        }
    }
}
