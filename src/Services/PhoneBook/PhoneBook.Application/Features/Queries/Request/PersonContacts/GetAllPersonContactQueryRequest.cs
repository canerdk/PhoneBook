using MediatR;
using PhoneBook.Application.Features.Queries.Response.PersonContacts;

namespace PhoneBook.Application.Features.Queries.Request.PersonContacts
{
    public class GetAllPersonContactQueryRequest : IRequest<IEnumerable<GetAllPersonContactQueryResponse>>
    {
    }
}
