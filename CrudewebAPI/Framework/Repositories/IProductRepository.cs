using DevSkill.Data;
using Framework.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repositories
{
    public interface IProductRepository:IRepository<Product,int>
    {
    }
}
