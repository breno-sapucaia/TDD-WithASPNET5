﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Dominio.Entity.Cursos
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
    }
}
