using DevSkill.Data;
using Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public interface IProjectUnitOfWork:IUnitOfWork
    {
          IProductRepository ProductRepository { get; }

    }
}
