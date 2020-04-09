using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class File
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public byte[] Data { get; set; }
        public virtual List<Material> Materials { get; set; }
    }
}
