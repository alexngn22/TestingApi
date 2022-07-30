using TestingApi.Models.Domain;
using TestingApi.Models.Interfaces;
using TestingApi.NHibernate.Helpers;

namespace TestingApi.NHibernate.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int GetUserID(User user)
        {
            using (var session = NHibernateHelper.Instance.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var userFromDB = session.QueryOver<User>()
                    .WhereRestrictionOn(x => x.LastName).IsInsensitiveLike(user.LastName)
                    .AndRestrictionOn(x => x.FirstName).IsInsensitiveLike(user.FirstName)
                    .SingleOrDefault();

                if (userFromDB != null)
                {
                    return userFromDB.ID;
                }

                int userID = (int)session.Save(user);
                tran.Commit();
                return userID;
            }
        }
    }
}
