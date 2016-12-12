using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class FileLibrary : EntityBase<int>
    {
        public string OldFileName { get; set; }

        public string NewFileName { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public int AlbumID { get; set; }

        public virtual Album Album { get; set; }

    }
}
