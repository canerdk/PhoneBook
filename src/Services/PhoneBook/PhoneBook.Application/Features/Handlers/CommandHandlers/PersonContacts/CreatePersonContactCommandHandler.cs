using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Commands.Request.PersonContacts;
using PhoneBook.Application.Features.Commands.Response.PersonContacts;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Application.Features.Handlers.CommandHandlers.PersonContacts
{
    public class CreatePersonContactCommandHandler : IRequestHandler<CreatePersonContactCommandRequest, CreatePersonContactCommandResponse>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IMapper _mapper;

        public CreatePersonContactCommandHandler(IPersonContactRepository personContactRepository, IMapper mapper)
        {
            _personContactRepository = personContactRepository;
            _mapper = mapper;
        }

        public async Task<CreatePersonContactCommandResponse> Handle(CreatePersonContactCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _personContactRepository.AddAsync(_mapper.Map<PersonContact>(request));
            return _mapper.Map<CreatePersonContactCommandResponse>(result);
        }
    }
}
