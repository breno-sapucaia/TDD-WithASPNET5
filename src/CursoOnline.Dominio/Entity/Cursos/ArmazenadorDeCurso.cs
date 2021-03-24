using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Dominio.Entity.Cursos;
using CursoOnline.Dominio.Enums;

namespace CursoOnline.Dominio
{
    public class ArmazenadorDeCurso
    {
        public readonly ICursoRepositorio _cursoRepositorio;
        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }


        public void Armazenar(CursoDTO cursoDTO)
        {

            var cursoJaSalvo = _cursoRepositorio.ObterPeloNome(cursoDTO.Nome);

            if (cursoJaSalvo != null)
                throw new ArgumentException("Nome do curso já consta no banco de dados");

            if (!Enum.TryParse<PublicoAlvo>(cursoDTO.PublicoAlvo, out var publicoAlvo))
                throw new ArgumentException("Publico alvo inválido");

            var curso = new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria, publicoAlvo, cursoDTO.Valor);

            _cursoRepositorio.Adicionar(curso);

        }
    }
}
