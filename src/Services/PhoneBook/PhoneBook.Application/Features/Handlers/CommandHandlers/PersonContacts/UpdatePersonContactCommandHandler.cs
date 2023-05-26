using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Commands.Request.PersonContacts;
using PhoneBook.Application.Features.Commands.Response.PersonContacts;

namespace PhoneBook.Application.Features.Handlers.CommandHandlers.PersonContacts
{
    public class UpdatePersonContactCommandHandler : IRequestHandler<UpdatePersonContactCommandRequest, UpdatePersonContactCommandResponse>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IMapper _mapper;

        public UpdatePersonContactCommandHandler(IPersonContactRepository personContactRepository, IMapper mapper)
        {
            _personContactRepository = personContactRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePersonContactCommandResponse> Handle(UpdatePersonContactCommandRequest request, CancellationToken cancellationToken)
        {
            var person = await _personContactRepository.GetAsync(x => x.Id == request.Id);
            if(person != null)
            {
                var result = await _personContactRepository.UpdateAsync(_mapper.Map(request, person));
                return _mapper.Map<UpdatePersonContactCommandResponse>(result);
            }

            return null;
        }
    }
}
