using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class Photo : EntityBase<int>
    {
        public string Name { get; set; }

        public string MimeType { get; set; }

        public byte[] Content { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
