using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using InnovativeProduct.InfrastructureServices.Gateways.Database;
using InnovativeProduct.WebService.InfrastructureServices.Gateways;
using InnovativeProduct.WebService.Scheduler;
using System.IO;

namespace InnovativeProduct.WebService.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {

        public ScheduleTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override string Schedule => "*/1 * * * *";

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/593/rows?$top=3&api_key=fee68e1ff9da6aa97c7deb04d48c82d1");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\"));
            string newnewpath = System.IO.Path.Combine(newPath, "InnovativeProduct.WebService", "InnovativeProduct.db");
            optionsBuilder.UseSqlite($"Data Source={newnewpath}");
            var context = new ProductContext(options: optionsBuilder.Options);
            context.Database.ExecuteSqlRaw("DELETE FROM Products");
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
        
            
            Console.WriteLine("Updated db.");
            return Task.CompletedTask;
        }
    }
}
