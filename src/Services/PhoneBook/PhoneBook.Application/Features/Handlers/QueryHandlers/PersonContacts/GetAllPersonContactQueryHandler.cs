using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Queries.Request.PersonContacts;
using PhoneBook.Application.Features.Queries.Response.PersonContacts;

namespace PhoneBook.Application.Features.Handlers.QueryHandlers.PersonContacts
{
    public class GetAllPersonContactQueryHandler : IRequestHandler<GetAllPersonContactQueryRequest, IEnumerable<GetAllPersonContactQueryResponse>>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IMapper _mapper;

        public GetAllPersonContactQueryHandler(IPersonContactRepository personContactRepository, IMapper mapper)
        {
            _personContactRepository = personContactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllPersonContactQueryResponse>> Handle(GetAllPersonContactQueryRequest request, CancellationToken cancellationToken)
        {
            var results = await _personContactRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllPersonContactQueryResponse>>(results);
        }
    }
}
