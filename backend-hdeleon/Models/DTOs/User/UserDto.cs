namespace backend_hdeleon.Models.DTOs.User
{
    public class UserDto
    {
        private int Id { get; set; }

        private string Name { get; set; } = null!;

        private string Email { get; set; } = null!;

        private string Password { get; set; } = null!;

        private string UserName { get; set; } = null!;
    }
}
