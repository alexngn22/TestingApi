using Microsoft.AspNetCore.Mvc;
using TestingApi.Models.Domain;
using TestingApi.Models.Interfaces;

namespace TestingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;

        public ResultsController(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var userCount = _resultRepository.GetUserCount();
            var results = _resultRepository.GetAll();
            return Ok(new { UserCount = userCount, Results = results });
        }

        [HttpPost]
        public ActionResult PostResult([FromBody] Result result)
        {
            _resultRepository.Save(result);
            return Ok();
        }
    }
}
