namespace TestingApi.Models.Domain
{
    public class Answer
    {
        public virtual int ID { get; set; }
        public virtual int QuestionID { get; set; }
        public virtual int Number { get; set; }
        public virtual string Text { get; set; }
        //public virtual bool? IsCorrect { get; set; }
    }
}
