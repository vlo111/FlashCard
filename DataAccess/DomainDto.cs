namespace DataAccess
{
    using System.Collections;
    using System.Collections.Generic;

    public class DomainDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public ICollection<QuestionDto> Question { get; set; }
    }
}
