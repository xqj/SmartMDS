using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.Util
{
   public class SerurityHelper
    {
       public static string GetTimeToken()
       {
           return DateTime.Now.ToString("yyyyMMddHHmmssfff");
       }
    }
}
