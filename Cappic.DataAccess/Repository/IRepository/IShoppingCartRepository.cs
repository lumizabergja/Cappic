using BulkyBook.Models;
using Cappic.Models;

namespace Cappic.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart obj);
        
    }
}
