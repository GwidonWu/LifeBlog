using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Web.Test
{
   public interface IMefTest1:IMefTest<int>
   {
       string ShowTest();
   }
}
