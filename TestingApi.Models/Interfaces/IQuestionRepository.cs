using System.Collections.Generic;
using TestingApi.Models.Domain;

namespace TestingApi.Models.Interfaces
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
    }
}
