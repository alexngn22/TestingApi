using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using TestingApi.Models.Domain;
using TestingApi.Models.Dto;
using TestingApi.Models.Interfaces;
using TestingApi.NHibernate.Helpers;

namespace TestingApi.NHibernate.Repositories
{
    public class ResultRepository : IResultRepository
    {
        public IEnumerable<ResultsDto> GetAll()
        {
            using (var session = NHibernateHelper.Instance.OpenSession())
            {
                return session.CreateSQLQuery(
                    "SELECT q.QuestionNumber, " +
                        "SUM(CASE WHEN a.IsCorrect = 1 THEN 1 ELSE 0 END) AS CorrectAnswerCount, " +
                        "SUM(CASE WHEN a.IsCorrect IS NULL OR a.IsCorrect = 0 THEN 1 ELSE 0 END) AS IncorrectAnswerCount " +
                    "FROM Results r " +
                        "INNER JOIN Questions q ON q.QuestionID = r.QuestionID " +
                        "INNER JOIN Answers a ON a.AnswerID = r.AnswerID " +
                    "GROUP BY q.QuestionNumber")
                    .SetResultTransformer(Transformers.AliasToBean<ResultsDto>())
                    .List<ResultsDto>();
            }
        }

        public IEnumerable<UserResultDto> GetByUser(int userID)
        {
            using (var session = NHibernateHelper.Instance.OpenSession())
            {
                return session.CreateSQLQuery(
                    "SELECT q.QuestionNumber, q.QuestionText, a.AnswerText, " +
                    "ISNULL(a.IsCorrect, 0) AS IsCorrect " +
                    "FROM Results r " +
                        "INNER JOIN Questions q ON q.QuestionID = r.QuestionID " +
                        "INNER JOIN Answers a ON a.AnswerID = r.AnswerID " +
                    "WHERE r.UserID = :userID")
                    .SetInt32("userID", userID)
                    .SetResultTransformer(Transformers.AliasToBean<UserResultDto>())
                    .List<UserResultDto>();
            }

        }

        public int GetUserCount()
        {
            using (var session = NHibernateHelper.Instance.OpenSession())
            {
                return session.CreateCriteria<Result>()
                    .SetProjection(Projections.CountDistinct<Result>(x => x.UserID))
                    .UniqueResult<int>();
            }

        }

        public void Save(Result result)
        {
            using (var session = NHibernateHelper.Instance.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                result.UpdatedAt = DateTime.Now;
                session.Save(result);
                tran.Commit();
            }
        }
    }
}
