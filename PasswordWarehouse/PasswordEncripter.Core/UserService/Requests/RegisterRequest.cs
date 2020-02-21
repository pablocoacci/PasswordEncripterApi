
namespace PasswordEncripter.Core.UserService.Requests
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string PasswordApi { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Dni { get; set; }
        public string LastName { get; set; }
        public string PassEncripter { get; set; }
    }
}
