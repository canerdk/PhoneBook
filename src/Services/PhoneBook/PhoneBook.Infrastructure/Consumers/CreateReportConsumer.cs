using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using PhoneBook.Application.Features.Queries.Request.PersonContacts;
using PhoneBook.Domain.Common;

namespace PhoneBook.Infrastructure.Consumers
{
    public class CreateReportConsumer : IConsumer<CreateReportEvent>
    {
        private readonly IMediator _mediator;

        public CreateReportConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<CreateReportEvent> context)
        {
            var result = await _mediator.Send(new GetAllPersonContactQueryRequest());
            if(result.Any())
            {
                var filteredResult = result.Where(x => x.Content.Contains(context.Message.Location));
                await context.RespondAsync(new ReportResultEvent
                {
                    ReportId = context.Message.ReportId,
                    Location = context.Message.Location,
                    PersonCount = filteredResult.Count(),
                    PhoneNumberCount = filteredResult.Where(x => x.Type == ContactType.Phone).Count()
                });
            }
        }
    }
}
