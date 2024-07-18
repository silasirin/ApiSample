using ApiSample.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Domain.Entities
{
    public class Category: EntityBase, IEntityBase
    {
        public Category()
        {
              
              
        }
        public Category(int parentId, string name, int priority)
        {
            ParentId = parentId;
            Name= name;
            Priority = priority;
        }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }

        //Bir kategoride birden çok detay olur
        public ICollection<Detail> Details { get; set; }

        //Bir kategoride birden fazla ürün olur -- ilk yazılan kısım burası. Crud işlemleri için yorum satırına alındı
        //public ICollection<Product> Products { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
