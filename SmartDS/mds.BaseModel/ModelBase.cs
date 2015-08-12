using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.BaseModel
{
    public class ModelBase
    {
        /// <summary>
        /// 数据创建人
        /// </summary>
        public long CreateBy
        {
            set;
            get;
        }
        /// <summary>
        /// 数据创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 最近修改人
        /// </summary>
        public long ModifyBy
        {
            set;
            get;
        }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime ModifyTime
        {
            set;
            get;
        }
        /// <summary>
        /// 数据是否删除
        /// </summary>
        public bool IsDelete
        {
            set;
            get;
        }
        /// <summary>
        /// 删除人
        /// </summary>
        public long DeleteBy { set; get; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { set; get; }
    }
}
