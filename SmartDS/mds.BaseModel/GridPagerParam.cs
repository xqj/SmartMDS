using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.BaseModel
{
    public struct GridPagerParam
    {
        public int PageSize
        {
            set;
            get;
        }
        public int CurrentPage
        {
            set;
            get;
        }
    }
}
