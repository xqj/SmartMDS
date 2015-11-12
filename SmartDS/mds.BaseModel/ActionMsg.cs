using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace mds.BaseModel
{ 
    [DataContract]
    public class ActionMsg
    {
        public ActionMsg()
        {
            this.ActionResult = false;
            this.Message = "";
        }
        public ActionMsg(bool result,string message)
        {
            this.ActionResult = result;
            this.Message = message;
        }
        /// <summary>
        /// 方法执行结果
        /// 默认为false
        /// 预期结果true
        /// 非预期结果false
        /// </summary>
        [DataMember]
        public bool ActionResult
        {
            set;
            get;
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
    }
}
