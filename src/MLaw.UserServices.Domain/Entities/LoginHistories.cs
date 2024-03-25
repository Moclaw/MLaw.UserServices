using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLaw.UserServices.Entities
{
    [Table("LoginHistories")]
    public sealed class LoginHistories : BaseEntities
    {
        public Guid UserId { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public string OS { get; set; }
        public string Browser { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
