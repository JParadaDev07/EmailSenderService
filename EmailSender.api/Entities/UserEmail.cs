namespace EmailSender.api.Entities;

public class UserEmail
{
    public string To { get; set; } = null!;
    public string? Subject { get; set; }
    public string? Body { get; set; }
}