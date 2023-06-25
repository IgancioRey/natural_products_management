using AutoMapper;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Application.Features.Products.Queries.GetProductsList;
using Moq;
using NaturalProducts.Man.App.UnitTests.Mocks;
using NaturalProducts.Management.Application.Profiles;
using Shouldly;

namespace NaturalProducts.Man.App.UnitTests.Products.Queries
{
    public class GetProductsListQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandlerTests()
        {
            _mockProductRepository = RepositoryMocks.GetProductRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetProductsListTest()
        {
            var handler = new GetProductsListQueryHandler(_mockProductRepository.Object, _mapper);

            var result = await handler.Handle(new GetProductsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductListVm>>();

            result.Count.ShouldBe(3);
        }
    }
}
