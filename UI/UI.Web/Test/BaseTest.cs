using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Test
{
    public class BaseTest<T>:IMefTest<int>
    {
        public string Show()
        {
            return "Base";
        }
    }
}