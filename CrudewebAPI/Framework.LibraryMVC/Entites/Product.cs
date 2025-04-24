using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LibraryMVC.Entites
{
    public class Product:IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double Price { get; set; }
    }
}
