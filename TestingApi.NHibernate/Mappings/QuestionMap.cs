using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using TestingApi.Models.Domain;

namespace TestingApi.NHibernate.Mappings
{
    public class QuestionMap : ClassMapping<Question>
    {
        public QuestionMap()
        {
            Schema("dbo");
            Table("Questions");
            Id(p => p.ID, map => { map.Column("QuestionID"); map.Generator(Generators.Identity); });
            Property(p => p.Number, map => map.Column("QuestionNumber"));
            Property(p => p.Text, map => map.Column("QuestionText"));

            Set(p => p.Answers, c =>
            {
                c.Cascade(Cascade.None);
                c.Inverse(true);
                c.Key(k => k.Column("QuestionID"));
                c.Lazy(CollectionLazy.NoLazy);
            },
            r => r.OneToMany());
        }
    }
}
