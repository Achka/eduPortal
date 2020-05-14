using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Material
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public long FileId { get; set; }
        public virtual File File { get; set; }

        public long CourseId { get; set; }
        public virtual Course Course { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
