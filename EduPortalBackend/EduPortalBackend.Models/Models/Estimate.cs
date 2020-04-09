using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Estimate
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long HomeworkId { get; set; }
        public virtual Homework Homework { get; set; }

        public long Mark { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
