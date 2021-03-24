using System.Threading.Tasks;

namespace CursoOnline.Dominio.Entity.Base
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
