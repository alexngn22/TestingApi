using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingApi.Models.Domain;
using TestingApi.Models.Interfaces;

namespace TestingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetAll()
        {
            var result = _questionRepository.GetAll();
            return Ok(result);
        }
    }
}
