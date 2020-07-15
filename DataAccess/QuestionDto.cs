namespace DataAccess
{
    using System.Collections;
    using System.Collections.Generic;

    public class QuestionDto
    {
        public int Id { get; set; }

        public int DomainId { get; set; }

        public string Question { get; set; }

        public int QType { get; set; }

        public int Stscd { get; set; }

        public DomainDto Domain { get; set; }

        public ICollection<AnswerDto> Answers { get; set; }
    }
}
