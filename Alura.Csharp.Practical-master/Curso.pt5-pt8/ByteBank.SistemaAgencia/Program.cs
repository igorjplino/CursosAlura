using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            //contas.Sort(new ComparadorContaCorrentePorAgencia());
            //contas.Sort(); // ContaCorrente implementa a interface IComparable

            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }

            Console.ReadLine();
        }

        static void TestaSort()
        {
            var nomes = new List<string>()
            {
                "Wellington",
                "Guilherme",
                "Luana",
                "Ana"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            idades.AdicionarVarios(45, 89, 12);
            // ListExtensoes.AdicionarVarios(idades, 45, 89, 12);

            idades.AdicionarVarios(99, -1);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }

        static void TestarListaGenerica()
        {
            Lista<int> idades = new Lista<int>();

            idades.AdicionarVarios(5, 10, 15, 20, 25, 30, 35);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                Console.WriteLine($"Idade no indice {i} = {idades[i]}");
            }

            Console.WriteLine($"Remover");

            idades.Remover(5);
            idades.Remover(15);
            idades.Remover(25);
            idades.Remover(35);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                Console.WriteLine($"Idade no indice {i} = {idades[i]}");
            }

            Console.WriteLine(idades[4]);
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        public static void ExtrairValorCambio()
        {
            string url = "www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtratorDeArgumentosURL extrator = new ExtratorDeArgumentosURL(url);

            Console.WriteLine(extrator.GetValor("moedaOrigem")); // real
            Console.WriteLine(extrator.GetValor("moedaDestino")); // dolar
            Console.WriteLine(extrator.GetValor("valor")); // 1500
        }
    }
}
