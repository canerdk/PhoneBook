using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
