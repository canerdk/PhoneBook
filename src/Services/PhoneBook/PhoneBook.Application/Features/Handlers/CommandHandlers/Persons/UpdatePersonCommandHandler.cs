using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Application.Features.Commands.Request.Persons;
using PhoneBook.Application.Features.Commands.Response.Persons;
using PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Handlers.CommandHandlers.Persons
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommandRequest, UpdatePersonCommandResponse>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePersonCommandResponse> Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAsync(x => x.Id == request.Id);
            if(person != null)
            {
                var result = await _personRepository.UpdateAsync(_mapper.Map(request, person));
                return _mapper.Map<UpdatePersonCommandResponse>(result);
            }

            return null;
        }
    }
}
