using System;
namespace mds.BaseModel
{
    public class loginuser
    {
        public int LoginId { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Pwd { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
