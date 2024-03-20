using System;

namespace MLaw.UserServices.Entities
{
    public class LoginHistories : BaseEntities
    {
        public Guid UserId { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public string OS { get; set; }
        public string Browser { get; set; }
    }
}
