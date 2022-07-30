using System.Collections.Generic;
using TestingApi.Models.Domain;
using TestingApi.Models.Dto;

namespace TestingApi.Models.Interfaces
{
    public interface IResultRepository
    {
        void Save(Result result);
        IEnumerable<UserResultDto> GetByUser(int userID);
        /// <summary>
        /// Метод возвращает количество тестируемых.
        /// </summary>
        int GetUserCount();
        IEnumerable<ResultsDto> GetAll();
    }
}
