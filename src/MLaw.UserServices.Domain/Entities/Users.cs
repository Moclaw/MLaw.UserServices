using System.ComponentModel.DataAnnotations.Schema;

namespace MLaw.UserServices.Entities
{
    [Table("Users")]
    public sealed class Users : BaseEntities
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
