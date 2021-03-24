using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Dominio.Entity.Base;
using CursoOnline.Dominio.Enums;

namespace CursoOnline.Dominio.Entity.Cursos
{
    public class Curso : Entidade
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome Inválido");

            if (cargaHoraria < 1) throw new ArgumentException("Carga horária Inválida");

            if (valor < 1) throw new ArgumentException("Valor inválido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }
    }
}
