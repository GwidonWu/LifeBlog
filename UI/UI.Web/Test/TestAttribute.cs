using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Test
{
     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class TestAttribute:Attribute
    {
        public bool isAction { get; set; }

        public TestAttribute(bool isAction)
        {
            this.isAction= isAction;
        }

    }
}