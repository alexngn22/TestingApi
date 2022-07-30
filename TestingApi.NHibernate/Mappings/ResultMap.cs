using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using TestingApi.Models.Domain;

namespace TestingApi.NHibernate.Mappings
{
    public class ResultMap : ClassMapping<Result>
    {
        public ResultMap()
        {
            Schema("dbo");
            Table("Results");
            Id(p => p.ID, map => { map.Column("ResultID"); map.Generator(Generators.Identity); });
            Property(p => p.AnswerID, map => map.Column("AnswerID"));
            Property(p => p.QuestionID, map => map.Column("QuestionID"));
            Property(p => p.UserID, map => map.Column("UserID"));
            Property(p => p.UpdatedAt, map => map.Column("UpdatedAt"));
        }
    }
}
