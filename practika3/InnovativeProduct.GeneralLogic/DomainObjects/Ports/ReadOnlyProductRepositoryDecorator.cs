using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InnovativeProduct.DomainObjects.Repositories
{
    public abstract class ReadOnlyProductRepositoryDecorator : IReadOnlyProductRepository
    {
        private readonly IReadOnlyProductRepository _productRepository;

        public ReadOnlyProductRepositoryDecorator(IReadOnlyProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public virtual async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository?.GetAllProducts();
        }

        public virtual async Task<Product> GetProduct(long id)
        {
            return await _productRepository?.GetProduct(id);
        }

        public virtual async Task<IEnumerable<Product>> QueryProducts(ICriteria<Product> criteria)
        {
            return await _productRepository?.QueryProducts(criteria);
        }
    }
}
