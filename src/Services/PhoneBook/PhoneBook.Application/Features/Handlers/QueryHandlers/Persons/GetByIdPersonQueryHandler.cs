using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Queries.Request.Persons;
using PhoneBook.Application.Features.Queries.Response.Persons;

namespace PhoneBook.Application.Features.Handlers.QueryHandlers.Persons
{
    public class GetByIdPersonQueryHandler : IRequestHandler<GetByIdPersonQueryRequest, GetByIdPersonQueryResponse>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetByIdPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPersonQueryResponse> Handle(GetByIdPersonQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.GetAsync(x => x.Id == request.Id, include: i => i.Include(x => x.PersonContacts));
            return _mapper.Map<GetByIdPersonQueryResponse>(result);
        }
    }
}
