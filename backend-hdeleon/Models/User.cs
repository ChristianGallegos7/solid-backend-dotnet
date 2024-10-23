using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_hdeleon.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }

        private string Name { get; set; } = null!;

        private string Email { get; set; } = null!;

        private string Password { get; set; } = null!;

        private string UserName { get; set; } = null!;
    }
}
