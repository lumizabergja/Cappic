
using Cappic.Data;
using Cappic.DataAccess.Repository.IRepository;
using Cappic.DataAccess.Repository;
using Cappic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cappic.DataAccess.Repository
{
    public class LensRepository : Repository<Lens>, ILensRepository
    {
        private ApplicationDbContext _db;
        public LensRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Lens obj)
        {
            _db.Lenses.Update(obj);
        }
    }
}
