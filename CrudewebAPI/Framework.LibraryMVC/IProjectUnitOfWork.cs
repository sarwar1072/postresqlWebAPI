using DevSkill.Data;
using Framework.LibraryMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LibraryMVC
{
    public interface IProjectUnitOfWork:IUnitOfWork
    {
          IProductRepository ProductRepository { get; }

    }
}
