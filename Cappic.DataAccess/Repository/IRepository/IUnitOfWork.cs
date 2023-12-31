﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cappic.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ILensRepository Lens { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IProductRepository Product { get; }
        void Save();
    }
}
