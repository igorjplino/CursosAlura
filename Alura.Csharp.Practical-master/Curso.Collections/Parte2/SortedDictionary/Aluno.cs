using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedDictionary
{
    class Aluno
    {
        public Aluno(string nome, int matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }

        public string Nome { get; set; }
        public int Matricula { get; set; }

        public override string ToString()
        {
            return $"[Nome: {Nome} | Matrícula: {Matricula}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Aluno outroAluno)
            {
                return Nome.Equals(outroAluno.Nome);
            }

            return false;
        }

        public override int GetHashCode()
        {
            ///
            /// Toda vez que o método Equals for sobreescrito, o mesmo deve ser feito
            /// com o GetHasCode, para que a dispersão aconteça corretamente e a rapidez
            /// da busca depende do código de dispersão.
            /// 
            /// Importante sobre HashCode!
            /// 
            /// Dois objetos iguais possuem o mesmo hash code, porém o inverso 
            /// nem sempre é verdadeiro, ou seja, dois objetos com mesmo hash code 
            /// não são necessariamente iguais.

            return Nome.GetHashCode();
        }
    }
}
