using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TestingApi.Models.Domain;
using TestingApi.Models.Interfaces;

namespace TestingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IValidator<User> _userValidator;
        private readonly IUserRepository _userRepository;
        private readonly IResultRepository _resultRepository;

        public UsersController(IValidator<User> userValidator,
            IUserRepository userRepository, IResultRepository resultRepository)
        {
            _userValidator = userValidator;
            _userRepository = userRepository;
            _resultRepository = resultRepository;
        }

        [HttpGet("{userID:int}/results")]
        public ActionResult Get(int userID)
        {
            var result = _resultRepository.GetByUser(userID);
            return Ok(new { Results = result });
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] User user)
        {
            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = _userRepository.GetUserID(user);
            return Ok(result);
        }
    }
}
