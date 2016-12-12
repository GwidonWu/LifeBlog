using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Areas.Admin.Models
{
    public class ListModel
    {
        public Blog blogModel { get; set; }

        public BlogViewModel blogViewModel { get; set; }

    }
}