using System;
namespace mds.BaseModel
{
    public class Webuser
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Pwd { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string IDCard { get; set; }
        public string Nationality { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreateTime { get; set; }


        public bool Sex { get; set; }
    }
}
