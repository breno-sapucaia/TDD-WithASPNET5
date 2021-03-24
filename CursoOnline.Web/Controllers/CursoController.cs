using CursoOnline.Dominio.Entity.Cursos;
using CursoOnline.Web.Util;
using Microsoft.AspNetCore.Mvc;
using CursoOnline.Dominio;
using System.Collections.Generic;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        

        public CursoController(ArmazenadorDeCurso armazenadorDeCurso)
        {
            _armazenadorDeCurso = armazenadorDeCurso;
            
        }

        public IActionResult Index()
        {

            var cursos = new List<CursoParaListagemDTO>();
            return View("Index", PaginatedList<CursoParaListagemDTO>.Create(null, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDTO());
        }
        
        public IActionResult Salvar(CursoDTO model)
        {
            _armazenadorDeCurso.Armazenar(model);
            return Ok();
        }

    }
}
