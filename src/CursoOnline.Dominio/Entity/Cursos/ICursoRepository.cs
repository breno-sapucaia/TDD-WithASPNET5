using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Dominio.Entity;
using CursoOnline.Dominio.Entity.Base;

namespace CursoOnline.Dominio.Entity.Cursos
{
    public interface ICursoRepositorio : IRepositorio<Curso>
    {
        Curso ObterPeloNome(string nome);
    }
}
