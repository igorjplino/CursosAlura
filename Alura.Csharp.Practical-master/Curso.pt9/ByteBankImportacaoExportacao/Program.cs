using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {

            UsarStreamDeEntrada();

            Console.WriteLine("Finalizada a execução. . .");
            Console.ReadLine();
        }
    }
}
