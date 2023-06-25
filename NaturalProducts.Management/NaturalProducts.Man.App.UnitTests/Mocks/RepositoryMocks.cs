using MongoDB.Bson;
using Moq;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Man.App.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var almondsId = "649230513b2bda8d24f7c717";
            var walnutsId = "6492311723490d0ee63bd5e9";
            var riceId = "649896f2c21bf075d844f96b";

            var products = new List<Product>
            {
                new Product
                {
                    ProductId = almondsId,
                    Name = "Almendras x 500 grs",
                    Count = 1,
                    Price = 10,
                    SellingPrice = 15
                },
                new Product
                {
                    ProductId = walnutsId,
                    Name = "Nueces x 500 grs",
                    Count = 1,
                    Price = 12,
                    SellingPrice = 17
                },
                new Product
                {
                    ProductId = riceId,
                    Name = "Arroz x kg",
                    Count = 1,
                    Price = 20,
                    SellingPrice = 21
                }
            };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(products);

            mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(
                (Product product) =>
                {
                    products.Add(product);
                    return product;
                });

            return mockProductRepository;
        }
    }
}
