using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novoCadastro);
    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto)
            : base(contexto)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = dbSet.SingleOrDefault(o => o.Id == cadastroId);

            if (cadastroDB == null)
            {

            }

            cadastroDB.Update(novoCadastro);
            contexto.SaveChanges();

            return cadastroDB;
        }
    }
}
