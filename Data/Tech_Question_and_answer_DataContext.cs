using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tech_Question_and_answer_Forum_Final.Models;

namespace Tech_Question_and_answer_Forum_Final.Models
{
    public class Tech_Question_and_answer_DataContext : DbContext
    {
        public Tech_Question_and_answer_DataContext (DbContextOptions<Tech_Question_and_answer_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Tech_Question_and_answer_Forum_Final.Models.Answer> Answer { get; set; }

        public DbSet<Tech_Question_and_answer_Forum_Final.Models.ForumMember> ForumMember { get; set; }

        public DbSet<Tech_Question_and_answer_Forum_Final.Models.Question> Question { get; set; }
    }
}
