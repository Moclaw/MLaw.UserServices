using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLaw.UserServices.Entities
{
    [Table("RolesUsers")]
    public class RolesUsers
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
