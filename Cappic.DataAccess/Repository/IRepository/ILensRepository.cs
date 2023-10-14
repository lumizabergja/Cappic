using Cappic.Models;

namespace Cappic.DataAccess.Repository.IRepository
{
    public interface ILensRepository : IRepository<Lens>
    {
        void Update(Lens obj);
        
    }
}
