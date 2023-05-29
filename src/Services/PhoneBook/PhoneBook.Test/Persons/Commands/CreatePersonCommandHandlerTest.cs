using AutoMapper;
using MediatR;
using Moq;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Commands.Request.Persons;
using PhoneBook.Application.Features.Commands.Response.Persons;
using PhoneBook.Application.Features.Handlers.CommandHandlers.Persons;
using PhoneBook.Application.Mapping;
using PhoneBook.Domain.Entities;
using PhoneBook.Test.Mocks;
using Shouldly;

namespace PhoneBook.Test.Persons.Commands
{
    public class CreatePersonCommandHandlerTest
    {
        private readonly Mock<IPersonRepository> _personRepositoryMock;
        private readonly CreatePersonCommandHandler _handler;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandlerTest()
        {
            _personRepositoryMock = MockPersonRepository.GetPersonsRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new CreatePersonCommandHandler(_personRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Valid_Person_Added()
        {
            var command = new CreatePersonCommandRequest() { FirsName = "caner", LastName = "demirkaya", Company = "asd" };
            var result = await _handler.Handle(command, CancellationToken.None);
            result.ShouldBeOfType<CreatePersonCommandResponse>();
            result.ShouldNotBeNull();
        }
    }
}
