using DevSkill.Data;
using Framework.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repositories
{
    public class ProductRepository : Repository<Product,int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        
       
    }
}
