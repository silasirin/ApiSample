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
        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priority { get; set; }

        //Bir kategoride birden çok detay olur
        public ICollection<Detail> Details { get; set; }

        //Bir kategoride birden fazla ürün olur
        public ICollection<Product> Products { get; set; }
    }
}
