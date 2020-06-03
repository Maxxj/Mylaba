using InnovativeProduct.DomainObjects;
using InnovativeProduct.ApplicationServices.Ports.Gateways.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace InnovativeProduct.InfrastructureServices.Gateways.Database
{
    public class ProductEFSqliteGateway : IProductDatabaseGateway
    {
        private readonly ProductContext _productContext;

        public ProductEFSqliteGateway(ProductContext productContext)
            => _productContext = productContext;

        public async Task<Product> GetProduct(long id)
           => await _productContext.Products.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetAllProducts()
            => await _productContext.Products.ToListAsync();

        public async Task<IEnumerable<Product>> QueryProducts(Expression<Func<Product, bool>> filter)
            => await _productContext.Products.Where(filter).ToListAsync();

        public async Task AddProduct(Product product)
        {
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _productContext.Entry(product).State = EntityState.Modified;
            await _productContext.SaveChangesAsync();
        }

        public async Task RemoveProduct(Product product)
        {
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();
        }
    }
}
