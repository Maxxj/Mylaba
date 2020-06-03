using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovativeProduct.ApplicationServices.Repositories
{
    public class InMemoryProductRepository : IReadOnlyProductRepository,
                                           IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public InMemoryProductRepository(IEnumerable<Product> products = null)
        {
            if (products != null)
            {
                _products.AddRange(products);
            }
        }

        public Task AddProduct(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        public Task<Product> GetProduct(long id)
        {
            return Task.FromResult(_products.Where(o => o.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Product>> QueryProducts(ICriteria<Product> criteria)
        {
            return Task.FromResult(_products.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveProduct(Product product)
        {
            _products.Remove(product);
            return Task.CompletedTask;
        }

        public Task UpdateProduct(Product product)
        {
            var foundProduct = GetProduct(product.Id).Result;
            if (foundProduct == null)
            {
                AddProduct(product);
            }
            else
            {
                if (foundProduct != product)
                {
                    _products.Remove(foundProduct);
                    _products.Add(product);
                }
            }
            return Task.CompletedTask;
        }
        public Task ParseAndPush()
        {
            throw new NotImplementedException();
        }
    }
}
