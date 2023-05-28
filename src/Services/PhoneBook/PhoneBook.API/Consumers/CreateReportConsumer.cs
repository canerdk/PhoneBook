using EventBus.Messages.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Domain.Common;

namespace PhoneBook.API.Consumers
{
    public class CreateReportConsumer : IConsumer<CreateReportEvent>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IPersonRepository _personRepository;

        public CreateReportConsumer(IPersonContactRepository personContactRepository, IPersonRepository personRepository)
        {
            _personContactRepository = personContactRepository;
            _personRepository = personRepository;
        }

        public async Task Consume(ConsumeContext<CreateReportEvent> context)
        {
            var result = await _personRepository.GetAllAsync(x => x.PersonContacts.Any(c => c.Type == ContactType.Location && c.Content.Contains(context.Message.Location)), include: i => i.Include(x => x.PersonContacts));
            if(result.Any())
            {
                await context.RespondAsync<ReportResultEvent>(new 
                {
                    ReportId = context.Message.ReportId,
                    Location = context.Message.Location,
                    PersonCount = result.Count(),
                    PhoneNumberCount = result.SelectMany(x => x.PersonContacts.Where(x => x.Type == ContactType.Phone)).Count()
                });
            }
        }
    }
}
