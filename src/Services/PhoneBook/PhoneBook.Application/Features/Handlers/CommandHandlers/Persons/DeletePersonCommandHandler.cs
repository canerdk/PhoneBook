using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Commands.Request.Persons;
using PhoneBook.Application.Features.Commands.Response.Persons;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Application.Features.Handlers.CommandHandlers.Persons
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommandRequest, DeletePersonCommandResponse>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public DeletePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<DeletePersonCommandResponse> Handle(DeletePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAsync(x => x.Id == request.Id);
            if (person != null)
            {
                var result = await _personRepository.DeleteAsync(person);
                return _mapper.Map<DeletePersonCommandResponse>(result);
            }

            return null;
        }
    }
}
