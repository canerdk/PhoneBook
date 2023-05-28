using EventBus.Messages.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.API.Entities;
using Report.API.Repositories.Abstract;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDetailsController : ControllerBase
    {
        private readonly IReportDetailRepository _reportDetailRepository;

        public ReportDetailsController(IReportDetailRepository reportDetailRepository)
        {
            _reportDetailRepository = reportDetailRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _reportDetailRepository.GetAll();
            if(result != null) 
                return Ok(result);

            return NotFound();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _reportDetailRepository.GetAsync(x => x.Id == id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("GetByReportId")]
        public async Task<IActionResult> GetByReportId(string reportId)
        {
            var result = await _reportDetailRepository.GetAsync(x => x.ReportId == reportId);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ReportDetail reportDetail)
        {
            var result = await _reportDetailRepository.UpdateAsync(id, reportDetail);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _reportDetailRepository.DeleteAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }
}
