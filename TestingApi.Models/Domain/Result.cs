using System;

namespace TestingApi.Models.Domain
{
    public class Result
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int QuestionID { get; set; }
        public virtual int AnswerID { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
