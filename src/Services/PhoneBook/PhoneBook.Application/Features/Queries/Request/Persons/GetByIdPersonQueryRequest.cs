using MediatR;
using PhoneBook.Application.Features.Queries.Response.Persons;

namespace PhoneBook.Application.Features.Queries.Request.Persons
{
    public class GetByIdPersonQueryRequest : IRequest<GetByIdPersonQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdPersonQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
