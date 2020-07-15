namespace DataAccess
{
    public class AnswerDto
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int QuestionType { get; set; }

        public int Rnk { get; set; }

        public int WrongRnk { get; set; }

        public string Message { get; set; }

        public QuestionDto Question { get; set; }
    }
}
