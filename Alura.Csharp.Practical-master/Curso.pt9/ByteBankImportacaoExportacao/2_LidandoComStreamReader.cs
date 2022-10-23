using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void testandoStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();

                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = $"Conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";
                    Console.WriteLine(msg);
                }
            }
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nomeTitular = campos[3];

            var titular = new Cliente()
            {
                Nome = campos[3]
            };

            var resultado = new ContaCorrente(agencia, numero)
            {
                Titular = titular
            };

            resultado.Depositar(saldo);

            return resultado;
        }
    }
}
