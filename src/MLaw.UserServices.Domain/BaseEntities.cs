using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLaw.UserServices
{
    public class BaseEntities
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
