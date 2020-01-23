using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_Question_and_answer_Forum_Final.Models
{

    public class Answer
    {
        public int Id { get; set; }

        public string Contents { get; set; }

        public int ForumMemberId { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public ForumMember ForumMember { get; set;}




    }
}
