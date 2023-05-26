using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Commands.Request.PersonContacts;
using PhoneBook.Application.Features.Commands.Response.PersonContacts;

namespace PhoneBook.Application.Features.Handlers.CommandHandlers.PersonContacts
{
    public class DeletePersonContactCommandHandler : IRequestHandler<DeletePersonContactCommandRequest, DeletePersonContactCommandResponse>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IMapper _mapper;

        public DeletePersonContactCommandHandler(IPersonContactRepository personContactRepository, IMapper mapper)
        {
            _personContactRepository = personContactRepository;
            _mapper = mapper;
        }

        public async Task<DeletePersonContactCommandResponse> Handle(DeletePersonContactCommandRequest request, CancellationToken cancellationToken)
        {
            var person = await _personContactRepository.GetAsync(x => x.Id == request.Id);
            if (person != null)
            {
                var result = await _personContactRepository.DeleteAsync(person);
                return _mapper.Map<DeletePersonContactCommandResponse>(result);
            }

            return null;
        }
    }
}
