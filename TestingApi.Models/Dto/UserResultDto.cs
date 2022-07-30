namespace TestingApi.Models.Dto
{
    public class UserResultDto
    {
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
