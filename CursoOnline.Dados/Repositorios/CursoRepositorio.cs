using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoOnline.Dados.Contextos;
using CursoOnline.Dominio.Entity.Cursos;

namespace CursoOnline.Dados.Repositorios
{
    public class CursoRepositorio : RepositorioBase<Curso>, ICursoRepositorio
    {
        public CursoRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public Curso ObterPeloNome(string nome)
        {
            var entidade = Context.Set<Curso>().Where(c => c.Nome.Contains(nome));
            if (entidade.Any())
                return entidade.First();
            return null;
        }
    }
}
