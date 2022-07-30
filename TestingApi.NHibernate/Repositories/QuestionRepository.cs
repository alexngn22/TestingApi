using System.Collections.Generic;
using TestingApi.Models.Domain;
using TestingApi.Models.Interfaces;
using TestingApi.NHibernate.Helpers;

namespace TestingApi.NHibernate.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public IEnumerable<Question> GetAll()
        {
            using (var session = NHibernateHelper.Instance.OpenSession())
            {
                return session.QueryOver<Question>()
                    .List();
            }
        }
    }
}
