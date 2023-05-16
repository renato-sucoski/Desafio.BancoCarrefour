
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.BancoCarrefour.Authentication.DAOs
{
    [Table("User")]
    public class UserDAO
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        public string UserName { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required] 
        public string Salt { get; set; }
        [Required]
        public string RoleId { get; set; }
 
        [ForeignKey("RoleId")]
        public virtual RoleDAO Role { get; set; }
    }
}
