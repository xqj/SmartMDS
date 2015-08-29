using System;
namespace mds.BaseModel
{
    public class loginsession
    {
        public int SessionId { get; set; }
        public int LoginId { get; set; }
        public string SessionSign { get; set; }
        public DateTime CreateTime { get; set; }
        public int Timelength { get; set; }
        public string TimeUnit { get; set; }

    }
}
