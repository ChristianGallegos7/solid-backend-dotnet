namespace backend_hdeleon.Models.DTOs.User
{
    public class UserInsertDto
    {
        private string Name { get; set; } = null!;

        private string Email { get; set; } = null!;

        private string Password { get; set; } = null!;

        private string UserName { get; set; } = null!;
    }
}
