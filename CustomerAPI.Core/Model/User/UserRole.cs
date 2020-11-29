using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Core.Model.User
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("IsAdmin")]
        public bool IsAdmin { get; set; }
    }
}
