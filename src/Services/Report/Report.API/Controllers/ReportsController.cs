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

        public ReportsController(IPhoneBookReportRepository repository)
        {
            _repository = repository;
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

        [HttpPost]
        public async Task<IActionResult> Add(PhoneBookReport report)
        {
            var result = await _repository.AddAsync(report);
            return Ok(result);
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
