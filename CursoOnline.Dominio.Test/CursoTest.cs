using System;
using Bogus;
using CursoOnline.Dominio.Entity.Cursos;
using CursoOnline.Dominio.Enums;
using CursoOnline.Dominio.Test._Util;
using CursoOnline.Dominio.Test.Builders;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.Dominio.Test
{
    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly string _descricao;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor sendo executado");

            var faker = new Faker();

            _nome = faker.Random.Word();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(50, 100);
            _publicoAlvo = faker.Random.Enum<PublicoAlvo>();
            _valor = faker.Random.Double(50, 500);

        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executável");
        }
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
            };

            
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
            
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoUmNomeInvalido(string nomeInvalido)
        {   
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().Nome(nomeInvalido).Build()).ComMensagem("Nome Inválido");
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCArgaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().CargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga horária Inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmVvalorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().Valor(valorInvalido).Build()).ComMensagem("Valor inválido");
        }

       
    }


   
}
