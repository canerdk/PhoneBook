namespace PhoneBook.Application.Features.Commands.Response.Persons
{
    public class CreatePersonCommandResponse
    {
        public Guid Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
