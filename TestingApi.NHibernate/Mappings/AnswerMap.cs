using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using TestingApi.Models.Domain;

namespace TestingApi.NHibernate.Mappings
{
    public class AnswerMap : ClassMapping<Answer>
    {
        public AnswerMap()
        {
            Schema("dbo");
            Table("Answers");
            Id(p => p.ID, map => { map.Column("AnswerID"); map.Generator(Generators.Identity); });
            Property(p => p.QuestionID, map => map.Column("QuestionID"));
            Property(p => p.Number, map => map.Column("AnswerNumber"));
            Property(p => p.Text, map => map.Column("AnswerText"));
            //Property(p => p.IsCorrect, map => map.Column("IsCorrect"));
        }
    }
}
