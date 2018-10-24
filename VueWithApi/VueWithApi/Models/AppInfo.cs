namespace VueWithApi.Models
{
    public class AppInfo
    {
        public int MinimumPasswordStrength { get; set; }
        public int MinimumPasswordLength { get; set; }        
        public UserInfo User { get; set; }
        public string[] Permissions { get; set; }
    }
}
