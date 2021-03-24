using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Dominio.Entity.Cursos;
using CursoOnline.Dominio.Enums;

namespace CursoOnline.Dominio.Test.Builders
{
    public class CursoBuilder
    {
            private string _nome = "Informação básica";
            private double _cargaHoraria = 80;
            private PublicoAlvo _publicoAlvo = Enums.PublicoAlvo.Estudante;
            private double _valor = 950;
            private string _descricao = "uma descrição";
         public static CursoBuilder New()
        {
            return new CursoBuilder();
        }

        public CursoBuilder Nome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder Descricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder Valor(double valor)
        {
            _valor = valor;
            return this;
        }
        public CursoBuilder CargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder PublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
