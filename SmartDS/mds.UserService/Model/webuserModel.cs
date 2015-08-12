using System;
namespace mds.BaseModel
{
    public class webuser
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Mobile { get; set; }
        public string IDCard { get; set; }
        public string Nationality { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
