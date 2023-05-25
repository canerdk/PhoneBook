using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Commands.Request.Persons;
using PhoneBook.Application.Features.Commands.Response.Persons;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Application.Features.Handlers.CommandHandlers.Persons
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommandRequest, CreatePersonCommandResponse>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.AddAsync(_mapper.Map<Person>(request));
            return _mapper.Map<CreatePersonCommandResponse>(result);
        }
    }
}
