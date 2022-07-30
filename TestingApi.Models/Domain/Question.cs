using System.Collections.Generic;

namespace TestingApi.Models.Domain
{
    public class Question
    {
        public virtual int ID { get; set; }
        public virtual int Number { get; set; }
        public virtual string Text { get; set; }
        public virtual ISet<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}
