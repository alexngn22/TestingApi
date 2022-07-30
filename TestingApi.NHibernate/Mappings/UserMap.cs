using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using TestingApi.Models.Domain;

namespace TestingApi.NHibernate.Mappings
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Schema("dbo");
            Table("Users");
            Id(p => p.ID, map => { map.Column("UserID"); map.Generator(Generators.Identity); });
            Property(p => p.LastName, map => map.Column("LastName"));
            Property(p => p.FirstName, map => map.Column("FirstName"));
            Property(p => p.MiddleName, map => map.Column("MiddleName"));
        }
    }
}
