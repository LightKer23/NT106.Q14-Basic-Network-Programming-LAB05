namespace Bai02_Bai03
{
    public class UserInfo
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

        UserInfo()
        {
        }

        public UserInfo(string _email, string _password)
        {
            email = _email;
            password = _password;
        }
    }
}
