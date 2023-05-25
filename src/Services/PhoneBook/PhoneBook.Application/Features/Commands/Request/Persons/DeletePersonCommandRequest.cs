using MediatR;
using PhoneBook.Application.Features.Commands.Response.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Commands.Request.Persons
{
    public class DeletePersonCommandRequest : IRequest<DeletePersonCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
