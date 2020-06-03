using System;
using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using InnovativeProduct.ApplicationServices.Ports.Gateways.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovativeProduct.ApplicationServices.Repositories
{
    public class DbProductRepository : IReadOnlyProductRepository,
                                     IProductRepository
    {
        private readonly IProductDatabaseGateway _databaseGateway;

        public DbProductRepository(IProductDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<Product> GetProduct(long id)
            => await _databaseGateway.GetProduct(id);

        public async Task<IEnumerable<Product>> GetAllProducts()
            => await _databaseGateway.GetAllProducts();

        public async Task<IEnumerable<Product>> QueryProducts(ICriteria<Product> criteria)
            => await _databaseGateway.QueryProducts(criteria.Filter);

        public async Task AddProduct(Product product)
            => await _databaseGateway.AddProduct(product);

        public async Task RemoveProduct(Product product)
            => await _databaseGateway.RemoveProduct(product);

        public async Task UpdateProduct(Product product)
            => await _databaseGateway.UpdateProduct(product);

        public async Task ParseAndPush()
            => await _databaseGateway.ParseAndPush();
    }
}
