using InnovativeProduct.ApplicationServices.Ports.Cache;
using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using InnovativeProduct.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InnovativeProduct.InfrastructureServices.Repositories
{
    public class CachedReadOnlyProductRepository : ReadOnlyProductRepositoryDecorator
    {
        private readonly IDomainObjectsCache<Product> _productsCache;

        public CachedReadOnlyProductRepository(IReadOnlyProductRepository productRepository,
                                             IDomainObjectsCache<Product> productsCache)
            : base(productRepository)
            => _productsCache = productsCache;

        public async override Task<Product> GetProduct(long id)
            => _productsCache.GetObject(id) ?? await base.GetProduct(id);

        public async override Task<IEnumerable<Product>> GetAllProducts()
            => _productsCache.GetObjects() ?? await base.GetAllProducts();

        public async override Task<IEnumerable<Product>> QueryProducts(ICriteria<Product> criteria)
            => _productsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryProducts(criteria);
    }
}
