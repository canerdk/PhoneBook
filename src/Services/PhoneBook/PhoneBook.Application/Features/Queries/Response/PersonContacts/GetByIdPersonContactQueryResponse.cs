using PhoneBook.Domain.Common;

namespace PhoneBook.Application.Features.Queries.Response.PersonContacts
{
    public class GetByIdPersonContactQueryResponse
    {
        public Guid Id { get; set; }
        public ContactType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid PersonId { get; set; }
    }
}
