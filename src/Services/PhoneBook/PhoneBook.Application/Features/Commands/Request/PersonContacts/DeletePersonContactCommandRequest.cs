using MediatR;
using PhoneBook.Application.Features.Commands.Response.PersonContacts;

namespace PhoneBook.Application.Features.Commands.Request.PersonContacts
{
    public class DeletePersonContactCommandRequest : IRequest<DeletePersonContactCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
