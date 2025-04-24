using DevSkill.Data;
using Framework.LibraryMVC.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LibraryMVC.Repositories
{
    public interface IProductRepository:IRepository<Product,int>
    {
    }
}
