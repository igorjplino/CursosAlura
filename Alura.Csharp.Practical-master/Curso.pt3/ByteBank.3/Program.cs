using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //CalcularBonificacao();

            UsarSistema();

            Console.ReadLine();
        }

        public static void CalcularBonificacao()
        {
            var gerenciarBonificacao = new GerenciadorBonificacao();

            var auxiliar = new Auxiliar("123.456.789-00")
            {
                Nome = "João"
            };

            var diretor = new Diretor("987.654.321-00")
            {
                Nome = "Maria"
            };

            var designer = new Designer("654.789.123-55")
            {
                Nome = "Raimundo"
            };

            var gerenteDeContas = new GerenteDeConta("798.456.123-55")
            {
                Nome = "Joana"
            };

            var desenvolvedor = new Desenvolvedor("564.321.879-91")
            {
                Nome = "Pedro"
            };

            Console.WriteLine("Diretor: " + diretor.Nome);
            Console.WriteLine("Salário: " + diretor.Salario);
            Console.WriteLine("Bonificação: " + diretor.GetBonificacao());

            Console.WriteLine("Auxiliar: " + auxiliar.Nome);
            Console.WriteLine("Salário: " + auxiliar.Salario);
            Console.WriteLine("Bonificação: " + auxiliar.GetBonificacao());

            Console.WriteLine("Designer: " + designer.Nome);
            Console.WriteLine("Salário: " + designer.Salario);
            Console.WriteLine("Bonificação: " + designer.GetBonificacao());

            Console.WriteLine("GerenteDeContas: " + gerenteDeContas.Nome);
            Console.WriteLine("Salário: " + gerenteDeContas.Salario);
            Console.WriteLine("Bonificação: " + gerenteDeContas.GetBonificacao());

            Console.WriteLine("Desenvolvedor: " + desenvolvedor.Nome);
            Console.WriteLine("Salário: " + desenvolvedor.Salario);
            Console.WriteLine("Bonificação: " + desenvolvedor.GetBonificacao());
        }

        public static void UsarSistema()
        {
            var sistemaInterno = new SistemaInterno();

            var diretor = new Diretor("987.654.321-00")
            {
                Nome = "Maria",
                Senha = "321"
            };

            var gerenteDeContas = new GerenteDeConta("798.456.123-55")
            {
                Nome = "Joana",
                Senha = "123"
            };

            var parceiroComercial = new ParceiroComercial
            {
                Senha = "987"
            };

            sistemaInterno.Logar(parceiroComercial, "987");
            sistemaInterno.Logar(diretor, "123");
            sistemaInterno.Logar(gerenteDeContas, "123");
        }
    }
}
