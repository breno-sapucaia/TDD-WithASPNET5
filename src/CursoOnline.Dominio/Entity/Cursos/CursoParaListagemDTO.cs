﻿namespace CursoOnline.Dominio.Entity.Cursos
{
    public class CursoParaListagemDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
    }
}