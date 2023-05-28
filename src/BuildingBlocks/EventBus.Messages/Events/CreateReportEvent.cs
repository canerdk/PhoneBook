using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public record CreateReportEvent
    {
        public string ReportId { get; set; }
        public string Location { get; set; }
    }
}
