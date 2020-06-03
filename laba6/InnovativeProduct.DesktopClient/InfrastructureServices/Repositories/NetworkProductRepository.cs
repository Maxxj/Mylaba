using InnovativeProduct.ApplicationServices.Ports.Cache;
using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InnovativeProduct.InfrastructureServices.Repositories
{
    public class NetworkProductRepository : NetworkRepositoryBase, IReadOnlyProductRepository
    {
        private readonly IDomainObjectsCache<Product> _productCache;

        public NetworkProductRepository(string host, ushort port, bool useTls, IDomainObjectsCache<Product> productCache)
            : base(host, port, useTls)
            => _productCache = productCache;

        public async Task<Product> GetProduct(long id)
            => CacheAndReturn(await ExecuteHttpRequest<Product>($"Product/{id}"));

        public async Task<IEnumerable<Product>> GetAllProducts()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Product>>($"Product"), allObjects: true);

        public async Task<IEnumerable<Product>> QueryProducts(ICriteria<Product> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Product>>($"Product"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<Product> CacheAndReturn(IEnumerable<Product> products, bool allObjects = false)
        {
            if (allObjects)
            {
                _productCache.ClearCache();
            }
            _productCache.UpdateObjects(products, DateTime.Now.AddDays(1), allObjects);
            return products;
        }

        private Product CacheAndReturn(Product product)
        {
            _productCache.UpdateObject(product, DateTime.Now.AddDays(1));
            return product;
        }
    }
}
