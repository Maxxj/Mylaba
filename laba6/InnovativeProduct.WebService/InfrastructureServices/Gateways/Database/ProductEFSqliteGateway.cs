using InnovativeProduct.DomainObjects;
using InnovativeProduct.ApplicationServices.Ports.Gateways.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using InnovativeProduct.ApplicationServices.Ports.Gateways.Database;
using System.Net;
using InnovativeProduct.WebService.InfrastructureServices.Gateways;
using System.Text;
using Newtonsoft.Json;

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

        public async Task ParseAndPush()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/593/rows?$top=7&api_key=fee68e1ff9da6aa97c7deb04d48c82d1");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionsBuilder.UseSqlite("Data Source=C:/Users/User/Downloads/practika6/practika6/InnovativeProduct.WebService/InnovativeProduct.db"); ;
            var context = new ProductContext(options: optionsBuilder.Options);
            context.Database.ExecuteSqlRaw("DELETE FROM TransferNodes");
            using (context)
            {
                foreach (var item in resultServer)
                {
                    DomainObjects.Product product = new DomainObjects.Product();
                    product.Name = item.Cells.Name;
                    product.ExpectedEffects = item.Cells.Effects;
                    product.Indicators = item.Cells.Indicators;
                    product.Tasks = item.Cells.Tasks;
                    product.Specifications = item.Cells.TechnicalCharacteristics;
                    context.Entry(product).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            await Task.CompletedTask;
        }
    }
}
