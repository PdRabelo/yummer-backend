using Microsoft.AspNetCore.Identity.UI.Services;

namespace yummer_backend.AuthServices;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}