using System.Collections.Generic;
using System.Linq;

namespace SimpleShoppingCartSession.Models
{
    public class ProductList
    {
        private List<Product> Products;

        public ProductList()
        {
            Products = new List<Product>() {
                new Product
                {
                    Id = "p01",
                    Name = "name 1",
                    Price = 4,
                    Photo = "p4.png"
                },
                new Product
                {
                    Id = "p02",
                    Name = "name 2",
                    Price = 2,
                    Photo = "p5.png"
                },
                new Product
                {
                    Id = "p03",
                    Name = "name 3",
                    Price = 8,
                    Photo = "p6.png"
                },
                new Product
                {
                    Id = "p04",
                    Name = "name 1",
                    Price = 4,
                    Photo = "p2.png"
                },
            };
        }

        public List<Product> findAll()
        {
            return Products;
        }

        public Product find(string id)
        {
            return Products.Where(p => p.Id == id).FirstOrDefault();
        }

    }
}
