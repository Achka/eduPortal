using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class File
    {
        public long Id { get; set; }

        [Required]
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public byte[] Data { get; set; }
        public virtual List<Material> Materials { get; set; }
    }
}
