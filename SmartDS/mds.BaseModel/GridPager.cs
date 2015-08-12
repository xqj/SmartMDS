using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace mds.BaseModel
{
   
    [DataContract]
    public class GridPager<T>
    {
        public GridPager(List<T> data, bool result)
        {
            Data = data;
            m_Result = result;
        }
        public GridPager(bool result)
        {
            m_Result = result;
        }
        private bool m_Result = false;
        [DataMember]
        public bool ActionResult
        {
            get
            {
                return m_Result;
            }
            set
            {
                m_Result = value;
            }
        }
        [DataMember]
        public int ErrorCode
        {
            set;
            get;
        }
        [DataMember]
        public int Code
        {
            set;
            get;
        }
        [DataMember]
        public string Message
        {
            set;
            get;
        }
        [DataMember]
        public int Total
        {
            set;
            get;
        }
        [DataMember]
        public int CurrentPage
        {
            set;
            get;
        }
        [DataMember]
        public int PageSize
        {
            set;
            get;
        }
        [DataMember]
        public List<T> Data
        {
            set;
            get;
        }


    }
}
