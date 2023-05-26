using AutoMapper;
using PhoneBook.Application.Features.Commands.Request.Persons;
using PhoneBook.Application.Features.Commands.Response.Persons;
using PhoneBook.Application.Features.Queries.Response.PersonContacts;
using PhoneBook.Application.Features.Queries.Response.Persons;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, CreatePersonCommandRequest>().ReverseMap();
            CreateMap<Person, CreatePersonCommandResponse>().ReverseMap();

            CreateMap<Person, UpdatePersonCommandRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonCommandResponse>().ReverseMap();

            CreateMap<Person, DeletePersonCommandResponse>().ReverseMap();

            CreateMap<Person, GetAllPersonQueryResponse>().ReverseMap();
            CreateMap<Person, GetByIdPersonQueryResponse>().ReverseMap();

            CreateMap<Person, GetAllPersonContactQueryResponse>().ReverseMap();
            CreateMap<Person, GetByIdPersonContactQueryResponse>().ReverseMap();
        }
    }
}
