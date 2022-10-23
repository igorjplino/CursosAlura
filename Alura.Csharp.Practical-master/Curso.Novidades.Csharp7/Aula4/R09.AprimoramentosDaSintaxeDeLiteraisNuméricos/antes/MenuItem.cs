using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp7.R09.antes
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            var usuario = new UsuarioBlog("Carlos Tavares",
                NivelUsuarioBlog.Reader |
                NivelUsuarioBlog.PostAuthor |
                NivelUsuarioBlog.Admin);

            Console.WriteLine($"Usuário: {usuario.Nome}");
            Console.WriteLine("=====================================");
            Console.WriteLine($"É leitor? {usuario.EhLeitor}");
            Console.WriteLine($"É autor de post? {usuario.EhAutorDePost}");
            Console.WriteLine($"É super usuário? {usuario.EhSuperUsuario}");
            Console.WriteLine($"É administrador? {usuario.EhAdmin}");

            Console.WriteLine();

            int massaAtomicaMagnesio = 24;
            Console.WriteLine("Elemento: Magnésio");
            Console.WriteLine("==================");
            Console.WriteLine($"Massa atômica em (g) de um átomo: " +
                $"{Quimica.ObterMassaEmGramas(massaAtomicaMagnesio)}");
        }
    }

    public enum NivelUsuarioBlog
    {
        Reader = 1,
        PostAuthor = 2,
        SuperUser = 4,
        Admin = 8
    }

    class UsuarioBlog
    {
        public UsuarioBlog(string nome, NivelUsuarioBlog nivel)
        {
            Nome = nome;
            Nivel = nivel;
        }

        public string Nome { get; }
        public NivelUsuarioBlog Nivel { get; }

        public bool EhLeitor => (Nivel & NivelUsuarioBlog.Reader) == NivelUsuarioBlog.Reader;
        public bool EhAutorDePost => (Nivel & NivelUsuarioBlog.PostAuthor) == NivelUsuarioBlog.PostAuthor;
        public bool EhSuperUsuario => (Nivel & NivelUsuarioBlog.SuperUser) == NivelUsuarioBlog.SuperUser;
        public bool EhAdmin => (Nivel & NivelUsuarioBlog.Admin) == NivelUsuarioBlog.Admin;
    }


    class Quimica
    {
        const double CONSTANTE_AVOGADRO = 6.022140857747474e23;

        public static double ObterMassaEmGramas(int massAtomica)
        {
            //Exemplo:
            //========
            //Sabendo que a massa atômica do magnésio é igual a 24 u, 
            //determine a massa, em gramas, de um átomo desse elemento. 
            //    (Dado: Número de Avogadro = 6,0. 10^23).

            //Resposta
            //========
            //1 mol de átomos de Mg ↔ 24 g / mol ↔ 6,0. 10^23 átomos / mol
            //
            //x = 1 átomo x 24 g / mol
            //    --------------------
            //    6,0 x 10^23 átomos / mol
            //
            //x = 4,0 x 10^(-23) g.

            return massAtomica / CONSTANTE_AVOGADRO;
        }
    }
}
