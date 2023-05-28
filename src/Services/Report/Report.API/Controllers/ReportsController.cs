using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Report.API.Entities;
using Report.API.Repositories.Abstract;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IPhoneBookReportRepository _repository;
        private readonly IReportDetailRepository _reportDetailRepository;
        private readonly IRequestClient<CreateReportEvent> _client;

        public ReportsController(IPhoneBookReportRepository repository, IRequestClient<CreateReportEvent> client, IReportDetailRepository reportDetailRepository)
        {
            _repository = repository;
            _client = client;
            _reportDetailRepository = reportDetailRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _repository.GetAsync(x => x.Id == id);
            return Ok(result);
        }

        [HttpGet("GetReportByLocation")]
        public async Task<IActionResult> GetReportByLocation(string location)
        {
            //Create new report as preparing
            var addedResult = await _repository.AddAsync(new PhoneBookReport("Preparing"));
            if(addedResult != null)
            {
                //Send report id and location information to phonebook api
                var response = await _client.GetResponse<ReportResultEvent>(new { Location = location, ReportId  = addedResult.Id });

                var report = await _repository.GetAsync(x => x.Id == response.Message.ReportId);
                report.Status = "Prepared";
                var updatedResult = await _repository.UpdateAsync(report.Id, report);
                if(updatedResult != null)
                {
                    var reportDetail = await _reportDetailRepository.AddAsync(new ReportDetail()
                    {
                        Location = response.Message.Location,
                        PersonCount = response.Message.PersonCount,
                        PhoneNumberCount = response.Message.PhoneNumberCount,
                        ReportId = response.Message.ReportId
                    });
                    return Ok(reportDetail);
                }
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, PhoneBookReport report)
        {
            var result = await _repository.UpdateAsync(id, report);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
