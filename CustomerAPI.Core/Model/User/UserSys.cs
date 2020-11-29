using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Core.Model.User
{
    [Table("UserSys")]
    public class UserSys
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Login")]
        public string Login { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [ForeignKey("UserRole")]
        [Column("UserRoleId")]
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
