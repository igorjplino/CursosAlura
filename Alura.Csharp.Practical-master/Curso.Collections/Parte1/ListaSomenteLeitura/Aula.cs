using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSomenteLeitura
{
    class Aula : IComparable
    {
        public Aula(string titulo, int tempo)
        {
            Titulo = titulo;
            Tempo = tempo;
        }

        public string Titulo { get; set; }
        public int Tempo { get; set; }

        public int CompareTo(object obj)
        {
            var that = obj as Aula;

            if (that == null)
            {
                return -1;
            }

            return Titulo.CompareTo(that.Titulo);
        }

        public override string ToString()
        {
            return $"[Titulo: {Titulo} | Tempo: {Tempo}]";
        }
    }
}
