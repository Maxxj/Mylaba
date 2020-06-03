using InnovativeProduct.DesktopClient.InfrastructureServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;
using InnovativeProduct.InfrastructureServices.Gateways.Database;
using InnovativeProduct.WebService.InfrastructureServices.Gateways;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Data.Sqlite;

namespace InnovativeProduct.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            Button btn = new Button();
            btn.Name = "btn1";
            btn.Click += btn1_Click;
            DataContext = viewModel;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/593/rows?$top=7&api_key=fee68e1ff9da6aa97c7deb04d48c82d1");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
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
        }
    }
}