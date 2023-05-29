using Moq;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Test.Mocks
{
    public static class MockPersonRepository
    {
        public static Mock<IPersonRepository> GetPersonsRepository()
        {
            var persons = new List<Person>
            {
                new Person()
                {
                    Id = Guid.Parse("d6f2adb4-51a1-4ad1-80cb-b6136eafde2c"),
                    FirsName = "Caner",
                    LastName = "Demirkaya",
                    Company = "Company"
                },
                new Person()
                {
                    Id = Guid.Parse("113ca314-6bcb-467f-83c5-2277146f5b51"),
                    FirsName = "Mehmet",
                    LastName = "Demirkaya",
                    Company = "Company"
                },
                new Person()
                {
                    Id = Guid.Parse("512bf23c-7890-4a39-9f67-26e5fb51c65c"),
                    FirsName = "Ahmet",
                    LastName = "Demirkaya",
                    Company = "Company"
                }
            };

            var mockRepo = new Mock<IPersonRepository>();

            mockRepo.Setup(x => x.GetAllAsync(default,default,default)).ReturnsAsync(persons);

            mockRepo.Setup(x => x.AddAsync(It.IsAny<Person>())).ReturnsAsync((Person person) =>
            {
                persons.Add(person);
                return person;
            });

            return mockRepo;
        }
    }
}
