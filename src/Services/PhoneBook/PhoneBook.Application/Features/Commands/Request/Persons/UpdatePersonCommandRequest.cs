using MediatR;
using PhoneBook.Application.Features.Commands.Response.Persons;

namespace PhoneBook.Application.Features.Commands.Request.Persons
{
    public class UpdatePersonCommandRequest : IRequest<UpdatePersonCommandResponse>
    {
        public Guid Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
