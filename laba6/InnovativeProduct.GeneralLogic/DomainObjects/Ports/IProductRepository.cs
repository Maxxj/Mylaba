using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace InnovativeProduct.DomainObjects.Ports
{
    public interface IReadOnlyProductRepository
    {
        Task<Product> GetProduct(long id);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<IEnumerable<Product>> QueryProducts(ICriteria<Product> criteria);

    }

    public interface IProductRepository
    {
        Task AddProduct(Product product);

        Task RemoveProduct(Product product);
             
        Task UpdateProduct(Product product);
        Task ParseAndPush();
    }
}
