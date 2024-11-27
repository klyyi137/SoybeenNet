namespace XsoaApi.Core
{
    public class AuthUserInfoOut
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Buttons { get; set; }
    }
}