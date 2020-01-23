using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_Question_and_answer_Forum_Final.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int ForumMemberId { get; set; }

        public ForumMember ForumMember { get; set; }

       


    }
}
