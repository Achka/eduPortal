using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Homework
    {
        public long Id { get; set; }
        public long FileId { get; set; }
        public virtual File File { get; set; }

        public int UserId { get; set; }
        public virtual User  User {get; set;}

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
       
        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
