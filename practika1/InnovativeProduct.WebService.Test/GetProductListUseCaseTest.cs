using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using InnovativeProduct.ApplicationServices.Repositories;
using InnovativeProduct.ApplicationServices.Ports;
using InnovativeProduct.ApplicationServices.GetProductListUseCase;
using Xunit;
using InnovativeProduct.DomainObjects;

namespace InnovativeProduct.WebService.Tests
{
    public class GetProductListUseCaseTest
    {
        private InMemoryProductRepository CreateRoteRepository()
        {
            var repo = new InMemoryProductRepository(new List<Product> {
                new Product { Id = 1, Name = "Имя1", ExpectedEffects = "Ожидаемые эффекты1", Indicators = "Показатели1", Specifications = "Технические характеристики1", Tasks = "Задачи1"},
                new Product { Id = 2, Name = "Имя2", ExpectedEffects = "Ожидаемые эффекты2", Indicators = "Показатели2", Specifications = "Технические характеристики2", Tasks = "Задачи2"},
                new Product { Id = 3, Name = "Имя3", ExpectedEffects = "Ожидаемые эффекты3", Indicators = "Показатели3", Specifications = "Технические характеристики3", Tasks = "Задачи3"},
                new Product { Id = 4, Name = "Имя4", ExpectedEffects = "Ожидаемые эффекты4", Indicators = "Показатели4", Specifications = "Технические характеристики4", Tasks = "Задачи4"},
            });
            return repo;
        }

        [Fact]
        public void TestGetAllProducts()
        {
            var useCase = new GetProductListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetProductListUseCaseRequest.CreateAllProductsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Products.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Products.Select(o => o.Id));
        }

        [Fact]
        public void TestGetAllProductsFromEmptyRepository()
        {
            var useCase = new GetProductListUseCase(new InMemoryProductRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetProductListUseCaseRequest.CreateAllProductsRequest(), outputPort).Result);
            Assert.Empty(outputPort.Products);
        }

        [Fact]
        public void TestGetProduct()
        {
            var useCase = new GetProductListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetProductListUseCaseRequest.CreateProductRequest(2), outputPort).Result);
            Assert.Single(outputPort.Products, r => 2 == r.Id);
        }

        [Fact]
        public void TestTryGetNotExistingProduct()
        {
            var useCase = new GetProductListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetProductListUseCaseRequest.CreateProductRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Products);
        }

    }

    class OutputPort : IOutputPort<GetProductListUseCaseResponse>
    {
        public IEnumerable<Product> Products { get; private set; }

        public void Handle(GetProductListUseCaseResponse response)
        {
            Products = response.Products;
        }
    }

}
