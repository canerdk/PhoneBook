using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Common;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    Id = Guid.Parse("89049e21-eb04-40b2-9add-04dc29fa7d30"),
                    FirsName = "Caner",
                    LastName = "Demirkaya",
                    Company = "Company1"
                },
                new Person()
                {
                    Id = Guid.Parse("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"),
                    FirsName = "Ahmet",
                    LastName = "Demirkaya",
                    Company = "Company2"
                },
                new Person()
                {
                    Id = Guid.Parse("037f21f4-ee55-47e0-9696-ab540fd71b90"),
                    FirsName = "Mehmet",
                    LastName = "Demirkaya",
                    Company = "Company3"
                });

            modelBuilder.Entity<PersonContact>().HasData(
                new PersonContact() { Id = Guid.Parse("38a118f7-b516-47a4-9447-a3ef0732cb4c"), Title = "Location", Type = ContactType.Location, Content = "Ankara", PersonId = Guid.Parse("89049e21-eb04-40b2-9add-04dc29fa7d30") },
                new PersonContact() { Id = Guid.Parse("117781bc-9a13-43c6-af34-047e4e93345a"), Title = "Phone", Type = ContactType.Phone, Content = "5554443322", PersonId = Guid.Parse("89049e21-eb04-40b2-9add-04dc29fa7d30") },
                new PersonContact() { Id = Guid.Parse("932df542-135e-4363-b043-c61d72dd2460"), Title = "Phone", Type = ContactType.Phone, Content = "3334441112", PersonId = Guid.Parse("89049e21-eb04-40b2-9add-04dc29fa7d30") },
                new PersonContact() { Id = Guid.Parse("03371521-d91b-42dd-870d-c08ed467898d"), Title = "Location", Type = ContactType.Location, Content = "Ankara", PersonId = Guid.Parse("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf") },
                new PersonContact() { Id = Guid.Parse("75441eed-49bc-407b-9318-d3f6b247e7a6"), Title = "Phone", Type = ContactType.Phone, Content = "9998887744", PersonId = Guid.Parse("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf") },
                new PersonContact() { Id = Guid.Parse("ce22210a-1e2a-450d-9242-fbe5a4833b07"), Title = "Location", Type = ContactType.Location, Content = "İstanbul", PersonId = Guid.Parse("037f21f4-ee55-47e0-9696-ab540fd71b90") },
                new PersonContact() { Id = Guid.Parse("caf0dfd2-9436-4115-ab27-6b6c72df852f"), Title = "Phone", Type = ContactType.Phone, Content = "9998887744", PersonId = Guid.Parse("037f21f4-ee55-47e0-9696-ab540fd71b90") }
                );
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
    }
}
