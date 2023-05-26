using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Queries.Request.Persons;
using PhoneBook.Application.Features.Queries.Response.Persons;

namespace PhoneBook.Application.Features.Handlers.QueryHandlers.Persons
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQueryRequest, IEnumerable<GetAllPersonQueryResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetAllPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllPersonQueryResponse>> Handle(GetAllPersonQueryRequest request, CancellationToken cancellationToken)
        {
            var results = await _personRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetAllPersonQueryResponse>>(results);
        }
    }
}
