using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace csharp7.R05.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            var cidades = LerArquivo();
            var capitais = cidades.Where(c => c.Capital);
            foreach (var capital in capitais)
            {
                WriteLine(capital.Nome);
            }
        }

        private static IList<Cidade> LerArquivo()
        {
            IList<Cidade> cidades = new List<Cidade>();
            Encoding encoding = Encoding.GetEncoding(new CultureInfo("pt-BR").TextInfo.ANSICodePage);
            using (var streamReader = new StreamReader("cidades.csv", encoding))
            {
                streamReader.ReadLine();

                string linha;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    Tuple<string, string, double, double, bool> tupla = LerLinha(linha);
                    cidades.Add(new Cidade(tupla.Item1, tupla.Item2, tupla.Item5));
                }
            }
            return cidades;
        }

        private static Tuple<string, string, double, double, bool> LerLinha(string linha)
        {
            string[] campos = linha.Split(',');

            var estado = campos[0];
            var nome = campos[1];
            var latitude = double.Parse(campos[2]);
            var longitude = double.Parse(campos[3]);
            var capital = campos[4] == "true";

            return new Tuple<string, string, double, double, bool>
                (estado, nome, latitude, longitude, capital);
        }

        class Cidade
        {
            public string Estado { get; }
            public string Nome { get; }
            public bool Capital { get; }

            public Cidade(string estado, string nome, bool capital)
            {
                Estado = estado;
                Nome = nome;
                Capital = capital;
            }
        }
    }
}
