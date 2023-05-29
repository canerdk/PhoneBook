using AutoMapper;
using Moq;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Handlers.QueryHandlers.Persons;
using PhoneBook.Application.Features.Queries.Request.Persons;
using PhoneBook.Application.Features.Queries.Response.Persons;
using PhoneBook.Application.Mapping;
using PhoneBook.Test.Mocks;
using Shouldly;

namespace PhoneBook.Test.Persons.Queries
{
    public class GetAllPersonQueryHandlerTest
    {
        private readonly Mock<IPersonRepository> _personRepositoryMock;
        private readonly GetAllPersonQueryHandler _handler;
        private readonly IMapper _mapper;

        public GetAllPersonQueryHandlerTest()
        {
            _personRepositoryMock = MockPersonRepository.GetPersonsRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetAllPersonQueryHandler(_personRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task GetPersonListTest()
        {
            var query = new GetAllPersonQueryRequest();
            var result = await _handler.Handle(query, CancellationToken.None);
            result.ShouldBeOfType<List<GetAllPersonQueryResponse>>();
        }
    }
}
