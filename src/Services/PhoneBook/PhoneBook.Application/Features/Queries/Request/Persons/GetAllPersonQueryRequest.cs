using MediatR;
using PhoneBook.Application.Features.Queries.Response.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Queries.Request.Persons
{
    public class GetAllPersonQueryRequest : IRequest<IEnumerable<GetAllPersonQueryResponse>>
    {
    }
}
