using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace csharp7.R13.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            var cultura = new CultureInfo("pt-BR");

            var cliente = new Cliente("Zezinho da Silva");
            using (var streamReader = File.OpenText("filmes.csv"))
            {
                streamReader.ReadLine();

                string linha = string.Empty;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    string[] campos = linha.Split('|');
                    Locacao locacao =
                        new Locacao(campos[0],
                        int.Parse(campos[1]),
                        int.Parse(campos[2]),
                        int.Parse(campos[3]),
                        double.Parse(campos[4], NumberStyles.Currency, cultura));

                    cliente.Adicionar(locacao);
                }
            }

            WriteLine(new Resumo(cliente).GetResumo());
            WriteLine();

            WriteLine(new ResumoHTML(cliente).GetResumo());
            WriteLine();
        }
    }

    class Cliente
    {
        private const double PONTOS_POR_LOCACAO = 1.5;

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public IList<Locacao> Locacoes { get; } = new List<Locacao>();
        public double ValorTotal
        {
            get
            {
                return Locacoes.Sum(l => l.Preco);
            }
        }
        public double PontosDeFidelidade
        {
            get
            {
                return Locacoes.Count * PONTOS_POR_LOCACAO;
            }
        }

        public void Adicionar(Locacao locacao)
        {
            Locacoes.Add(locacao);
        }
    }

    abstract class BaseResumo
    {
        protected readonly Cliente cliente;

        public BaseResumo(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public string GetResumo()
        {
            var resultado = new StringBuilder();
            resultado.AppendLine(GetTitulo());
            resultado.AppendLine(GetQuebraDeLinha());
            foreach (var locacao in cliente.Locacoes)
            {
                resultado.AppendLine(GetDetalhe(locacao));
            }
            resultado.AppendLine(GetQuebraDeLinha());
            resultado.AppendLine(GetDebitos());
            resultado.AppendLine(GetPontos());
            return resultado.ToString();
        }

        protected abstract string GetPontos();

        protected abstract string GetDebitos();

        protected abstract string GetDetalhe(Locacao locacao);

        protected abstract string GetTitulo();

        protected abstract string GetQuebraDeLinha();
    }

    internal class ResumoHTML : BaseResumo
    {
        public ResumoHTML(Cliente cliente) : base(cliente)
        {
        }

        protected override string GetDebitos() => $"<p> Você deve: <em>{cliente.ValorTotal:C2}</em></p>";

        protected override string GetDetalhe(Locacao locacao) => locacao.Filme + GetQuebraDeLinha();

        protected override string GetPontos() => $"Você ganhou: {cliente.PontosDeFidelidade}</em> pontos.";

        protected override string GetTitulo() => $"<h1>Locações de <em>{cliente.Nome.ToUpper()}</em></h1>";

        protected override string GetQuebraDeLinha() => "<br/>";
    }

    internal class Resumo : BaseResumo
    {
        public Resumo(Cliente cliente) : base(cliente)
        {
        }

        protected override string GetDebitos() => $"Total devido: {cliente.ValorTotal}";

        protected override string GetDetalhe(Locacao locacao) => "\t" + locacao.Filme;

        protected override string GetPontos() => $"Você ganhou: {cliente.PontosDeFidelidade.ToString()} pontos";

        protected override string GetTitulo() => $"Resumo de locações de: {cliente.Nome.ToUpper()}";

        protected override string GetQuebraDeLinha() => "";
    }

    class Locacao
    {
        public Locacao(string filme, int dia, int mes, int ano, double preco)
        {
            this.Filme = filme;
            this.DataLocacao = new DateTime(ano, mes, dia);
            this.Preco = preco;
        }

        public string Filme { get; }

        public DateTime DataLocacao { get; }

        public DateTime DataExpiracao
        {
            get
            {
                return DataLocacao.Date + new TimeSpan(30, 0, 0, 0);
            }
        }

        public double Preco { get; }

        public void ImprimirDados()
        {
            WriteLine("Dados da Locacao");
            WriteLine(new string('=', 40));
            WriteLine($"filme: {Filme}");
            WriteLine($"preço: {Preco:C2}");
            WriteLine($"data da locação: {DataLocacao:dd/MM/yyyy}");
            WriteLine($"data da expiração: {DataExpiracao:dd/MM/yyyy}");
            WriteLine(new string('=', 40));
            WriteLine();
        }
    }
}
