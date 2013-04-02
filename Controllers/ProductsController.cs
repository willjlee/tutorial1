using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tutorial1.Models;

namespace tutorial1.Controllers
{
    public class ProductsController : ApiController
    {

        //populate "database"
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> GetAllProducts()
            //returns list of all products in "database"
        {
            return products;
        }

        public Product GetProductById(int id)
            //given an id, returns the corresponding product information
        {
            var product = products.FirstOrDefault((p) => p.Id == id);//finds first product with id. argument here is a lambda expression
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
            //returns list of products in indicated category
        {
            return products.Where(
                (p) => string.Equals(p.Category, category,
                    StringComparison.OrdinalIgnoreCase));//lambda expression again.
        }

    }
}
