using InnovativeProduct.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InnovativeProduct.ApplicationServices.Ports.Gateways.Database
{
    public interface IProductDatabaseGateway
    {
        Task AddProduct(Product product);

        Task RemoveProduct(Product product);

        Task UpdateProduct(Product product);

        Task<Product> GetProduct(long id);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<IEnumerable<Product>> QueryProducts(Expression<Func<Product, bool>> filter);
        Task ParseAndPush();
    }
}
