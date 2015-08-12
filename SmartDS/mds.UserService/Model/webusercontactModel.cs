using System;
namespace mds.BaseModel
{
    public class webusercontact
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public string HomeAddress { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
