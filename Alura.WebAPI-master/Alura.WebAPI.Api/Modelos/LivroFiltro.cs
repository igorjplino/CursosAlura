using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Modelos
{
    public class LivroFiltro
    {
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Lista { get; set; }
    }

    public static class LivroFiltroExtentions
    {
        public static IQueryable<Livro> AplicarFiltro(this IQueryable<Livro> query, LivroFiltro filtro)
        {
            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Titulo))
                {
                    query = query.Where(o => o.Titulo.Contains(filtro.Titulo));
                }
                
                if (!string.IsNullOrEmpty(filtro.Subtitulo))
                {
                    query = query.Where(o => o.Subtitulo.Contains(filtro.Subtitulo));
                }

                if (!string.IsNullOrEmpty(filtro.Autor))
                {
                    query = query.Where(o => o.Autor.Contains(filtro.Autor));
                }

                if (!string.IsNullOrEmpty(filtro.Lista))
                {
                    query = query.Where(o => o.Lista == filtro.Lista.ParaTipo());
                }
            }

            return query;
        }
    }
}
