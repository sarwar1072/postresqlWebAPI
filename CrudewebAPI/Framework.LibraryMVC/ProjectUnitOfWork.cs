using DevSkill.Data;
using Framework.LibraryMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LibraryMVC
{
    public class ProjectUnitOfWork:UnitOfWork, IProjectUnitOfWork
    {
        public IProductRepository ProductRepository { private set; get; }
        public ProjectUnitOfWork(ApplicationDbContext applicationDb, IProductRepository productRepository) : base(applicationDb)
        {
            ProductRepository = productRepository;
        }
    }
}
