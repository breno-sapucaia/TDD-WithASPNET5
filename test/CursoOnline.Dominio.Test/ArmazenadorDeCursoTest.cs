using System;
using Bogus;
using CursoOnline.Dominio.Entity.Cursos;
using CursoOnline.Dominio.Enums;
using CursoOnline.Dominio.Test._Util;
using CursoOnline.Dominio.Test.Builders;
using Moq;
using Xunit;

namespace CursoOnline.Dominio.Test
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDTO _cursoDTO;
        private readonly Mock<ICursoRepositorio> _cursoRepositoryMock;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            var faker = new Faker();
            _cursoDTO = new CursoDTO
            {
                Nome = faker.Random.Word(),
                Descricao = faker.Lorem.Paragraph(),
                CargaHoraria = faker.Random.Double(50,100),
                PublicoAlvo = "Estudante",
                Valor = faker.Random.Double(50,200)
            };
            _cursoRepositoryMock = new Mock<ICursoRepositorio>();

            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositoryMock.Object);

        }
        //verficar comportamento de algo ou alguma coisa externa do domínio mockada
        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDTO);

            _cursoRepositoryMock.Verify(r => r.Adicionar(It.Is<Curso>(
                c => c.Nome == _cursoDTO.Nome &&
                c.Descricao == _cursoDTO.Descricao
                )
            ));
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            

            _cursoDTO.PublicoAlvo = "Medico";
            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO)).ComMensagem("Publico alvo inválido");
        }

        // stub, modificar o mock e analisar se algo é acertivo com aquilo que espera.
        [Fact]
        public void NaoDeveAdicionarCursoComMesmoNomeDeOutroJaSalvo()
        {
            var cursoJaSalvo = CursoBuilder.New().Nome(_cursoDTO.Nome).Build();
            _cursoRepositoryMock.Setup(r => r.ObterPeloNome(_cursoDTO.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO)).ComMensagem("Nome do curso já consta no banco de dados");
        }
    }
    
}
