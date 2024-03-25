using System.ComponentModel.DataAnnotations.Schema;

namespace MLaw.UserServices.Entities
{
    [Table("Roles")]
    public class Roles : BaseEntities
    {
        public string Name { get; set; }
    }
}
