using ApiSample.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Domain.Entities
{
    public class Product: EntityBase
    {
        public Product()
        {
            
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        //Bir ürünün bir markası olur
        public Brand Brand { get; set; }

        //Bir ürünün birden fazla kategorisi olabilir
        public ICollection<Category> Categories { get; set; }
    }
}
