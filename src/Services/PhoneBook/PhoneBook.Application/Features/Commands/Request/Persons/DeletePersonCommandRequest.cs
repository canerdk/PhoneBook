using MediatR;
using PhoneBook.Application.Features.Commands.Response.Persons;

namespace PhoneBook.Application.Features.Commands.Request.Persons
{
    public class DeletePersonCommandRequest : IRequest<DeletePersonCommandResponse>
    {
        public Guid Id { get; set; }

        public DeletePersonCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
