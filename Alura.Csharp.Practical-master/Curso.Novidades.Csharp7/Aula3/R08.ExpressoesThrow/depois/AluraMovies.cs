using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace csharp7.R08.depois
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            try
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
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            WriteLine();

            try
            {
                Cliente cliente2 = new Cliente(null);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            try
            {
                Cliente cliente3 = new Cliente("Homer Simpson");
                cliente3.Adicionar(null);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            try
            {
                WriteLine(new ResumoHTML(null).GetResumo());
                WriteLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }

    class Cliente
    {
        private const double PONTOS_POR_LOCACAO = 1.5;

        public Cliente(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome), "Parâmetro não pode ser nulo.");
        }

        public string Nome { get; }

        public IList<Locacao> Locacoes { get; } = new List<Locacao>();

        public double ValorTotal => Locacoes.Sum(l => l.Preco);

        public double PontosDeFidelidade => Locacoes.Count * PONTOS_POR_LOCACAO;

        public void Adicionar(Locacao locacao) => Locacoes.Add(locacao);
    }

    abstract class BaseResumo
    {
        protected readonly Cliente cliente;

        public BaseResumo(Cliente cliente)
        {
            this.cliente = cliente ?? throw new ArgumentNullException(nameof(cliente), "Parâmetro não pode ser nulo.");
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

        protected string GetDetalhe(Locacao locacao)
        {
            if (locacao == null)
            {
                throw new ArgumentException("Parâmetro inválido", nameof(locacao));
            }
            return MontarDetalhe(locacao);
        }

        private string MontarDetalhe(Locacao locacao)
        {
            return locacao.Filme + GetQuebraDeLinha();
        }

        protected abstract string GetPontos();

        protected abstract string GetDebitos();

        protected abstract string GetTitulo();

        protected abstract string GetQuebraDeLinha();
    }

    internal class ResumoHTML : BaseResumo
    {
        public ResumoHTML(Cliente cliente) : base(cliente)
        {
        }

        protected override string GetDebitos() => $"<p> Você deve: <em>{cliente.ValorTotal:C2}</em></p>";

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

        public DateTime DataExpiracao => DataLocacao.Date + new TimeSpan(30, 0, 0, 0);

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
