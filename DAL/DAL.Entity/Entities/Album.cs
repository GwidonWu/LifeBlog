using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class Album : EntityBase<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public int Count { get; set; }

    }
}
