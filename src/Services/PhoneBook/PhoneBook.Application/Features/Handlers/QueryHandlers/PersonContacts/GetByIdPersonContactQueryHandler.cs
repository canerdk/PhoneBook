using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Queries.Request.PersonContacts;
using PhoneBook.Application.Features.Queries.Response.PersonContacts;

namespace PhoneBook.Application.Features.Handlers.QueryHandlers.PersonContacts
{
    public class GetByIdPersonContactQueryHandler : IRequestHandler<GetByIdPersonContactQueryRequest, GetByIdPersonContactQueryResponse>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IMapper _mapper;

        public GetByIdPersonContactQueryHandler(IPersonContactRepository personContactRepository, IMapper mapper)
        {
            _personContactRepository = personContactRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPersonContactQueryResponse> Handle(GetByIdPersonContactQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _personContactRepository.GetAsync(x => x.Id == request.Id);
            return _mapper.Map<GetByIdPersonContactQueryResponse>(result);
        }
    }
}
