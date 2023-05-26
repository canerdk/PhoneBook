using MediatR;
using PhoneBook.Application.Features.Queries.Response.PersonContacts;

namespace PhoneBook.Application.Features.Queries.Request.PersonContacts
{
    public class GetByIdPersonContactQueryRequest : IRequest<GetByIdPersonContactQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdPersonContactQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
