namespace EmailSender.api.Common.Others.Implementation.Settings;

public class EmailSettings
{
    public string MailServer { get; set; } = null!;
    public int MailPort { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}