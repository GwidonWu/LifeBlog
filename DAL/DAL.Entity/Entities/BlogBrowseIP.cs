using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Entities
{
    public class BlogBrowseIP : EntityBase<int>
    {
        public string BrowseIP { get; set; }

        public DateTime BrowseTime { get; set; }


        public int BlogID { get; set; }

        public virtual Blog Blog { get; set; }

    }
}
