using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

namespace csharp7.R14.antes
{
    public class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            using (var streamReader = File.OpenText("clientes.csv"))
            {
                string linha = string.Empty;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    string[] campos = linha.Split(',');

                    if (int.TryParse(campos[0], out var id))
                    {
                        Cliente cliente = new Cliente(id, campos[1], campos[2], campos[3]);

                        WriteLine("Dados do Cliente");
                        WriteLine("================");
                        WriteLine("ID: " + cliente.Id);
                        WriteLine("Nome: " + cliente.Nome);
                        WriteLine("Telefone: " + cliente.Telefone);
                        WriteLine("Website: " + cliente.Website);
                        WriteLine("================");
                    }

                    Console.WriteLine($"Valor do ID: {id}");
                }
            }
        }
    }

    class Cliente
    {
        readonly int id;
        readonly string nome;
        readonly string telefone;
        readonly string website;

        public int Id => id;

        public string Nome => nome;

        public string Telefone => telefone;

        public string Website => website;

        public Cliente(int id, string nome, string telefone, string website)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.website = website;
        }

    }
}
