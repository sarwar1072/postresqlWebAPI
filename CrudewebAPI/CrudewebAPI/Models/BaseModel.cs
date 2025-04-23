using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.CodeDom;

namespace CrudewebAPI.Models
{
    public abstract class BaseModel
    {
        protected ILifetimeScope? _lifetimeScope;
        public BaseModel()
        {
        }
      
       public virtual void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope=lifetimeScope;
        }
    

    }
}
