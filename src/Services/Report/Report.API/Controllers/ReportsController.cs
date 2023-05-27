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
        private readonly IRequestClient<CreateReportEvent> _client;

        public ReportsController(IPhoneBookReportRepository repository, IRequestClient<CreateReportEvent> client)
        {
            _repository = repository;
            _client = client;
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
            var result = await _repository.AddAsync(new PhoneBookReport("Preparing"));
            if(result != null)
            {
                var response = await _client.GetResponse<ReportResultEvent>(new CreateReportEvent { Location = location, ReportId  = result.Id });
                return Ok(response.Message);
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
