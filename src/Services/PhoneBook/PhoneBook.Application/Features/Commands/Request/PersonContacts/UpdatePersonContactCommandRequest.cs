using MediatR;
using PhoneBook.Application.Features.Commands.Response.PersonContacts;
using PhoneBook.Domain.Common;

namespace PhoneBook.Application.Features.Commands.Request.PersonContacts
{
    public class UpdatePersonContactCommandRequest : IRequest<UpdatePersonContactCommandResponse>
    {
        public Guid Id { get; set; }
        public ContactType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid PersonId { get; set; }
    }
}
