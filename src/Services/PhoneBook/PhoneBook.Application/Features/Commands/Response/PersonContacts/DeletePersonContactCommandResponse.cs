using PhoneBook.Domain.Common;

namespace PhoneBook.Application.Features.Commands.Response.PersonContacts
{
    public class DeletePersonContactCommandResponse
    {
        public Guid Id { get; set; }
        public ContactType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid PersonId { get; set; }
    }
}
