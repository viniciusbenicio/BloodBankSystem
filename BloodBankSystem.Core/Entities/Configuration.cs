namespace BloodBankSystem.Core.Entities
{
    public static class Configuration
    {
        public static SmtpConfiguration SMTP = new SmtpConfiguration();

    }

    public class SmtpConfiguration
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

}
