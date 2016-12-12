using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Areas.Admin.Models
{
    public class AlbumViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }
    }
}