using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    // Many to many relationship table betweeen students and courses
    public class UserCourse
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}
