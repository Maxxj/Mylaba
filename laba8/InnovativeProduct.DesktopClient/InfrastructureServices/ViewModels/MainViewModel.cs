using InnovativeProduct.ApplicationServices.GetProductListUseCase;
using InnovativeProduct.ApplicationServices.Ports;
using InnovativeProduct.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace InnovativeProduct.DesktopClient.InfrastructureServices.ViewModels 
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetProductListUseCase _getProductListUseCase;

        public MainViewModel(IGetProductListUseCase getProductListUseCase)
            => _getProductListUseCase = getProductListUseCase;

        private Task<bool> _loadingTask;
        private Product _currentProduct;
        private ObservableCollection<Product> _products;

        public event PropertyChangedEventHandler PropertyChanged;

        public Product CurrentProduct
        {
            get => _currentProduct;
            set
            {
                if (_currentProduct != value)
                {
                    _currentProduct = value;
                    OnPropertyChanged(nameof(CurrentProduct));
                }
            }
        }

        private async Task<bool> LoadProducts()
        {
            var outputPort = new OutputPort();
            bool result = await _getProductListUseCase.Handle(GetProductListUseCaseRequest.CreateAllProductsRequest(), outputPort);
            if (result)
            {
                Products = new ObservableCollection<Product>(outputPort.Products);
            }
            return result;
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadProducts();
                }

                return _products;
            }
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetProductListUseCaseResponse>
        {
            public IEnumerable<Product> Products { get; private set; }

            public void Handle(GetProductListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Products = new ObservableCollection<Product>(response.Products);
                }
            }
        }
    }
}
