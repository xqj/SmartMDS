using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace mds.BaseModel
{
    [DataContract]
    public class OperationResult<T>
    {
        public OperationResult(T data, bool result)
        {
            Data = data;
            m_Result = result;
            this.Message = "";
            
        }
        public OperationResult(bool result)
        {
            m_Result = result;
            this.Message = "";
            this.Data = default(T);
        }
        public OperationResult()
        {
            this.ActionResult = false;
            this.Message = "";
            this.Data = default(T);
        }
        private bool m_Result = false;
        /// <summary>
        /// 方法执行结果
        /// 默认为false
        /// 预期结果true
        /// 非预期结果false
        /// </summary>
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
        /// <summary>
        /// 错误代码
        /// 默认为0
        /// ActionResult为true时无意义
        /// </summary>
        [DataMember]
        public int ErrorCode
        {
            set;
            get;
        }
        /// <summary>
        /// 结果代码
        /// 默认为0
        /// 返回给调用方详细内部状态编码
        /// 如果调用方不要求可忽略
        /// </summary>
        [DataMember]
        public int Code
        {
            set;
            get;
        }
        /// <summary>
        /// 返回提示信息
        /// 默认为空
        /// 提供给方法调用方或者最终用户       
        /// </summary>
        [DataMember]
        public string Message
        {
            set;
            get;
        }
        /// <summary>
        /// 返回数据
        /// 默认default(T);
        /// </summary>
        [DataMember]
        public T Data
        {
            set;
            get;
        }
       
       
    }
}
