using EmailSender.api;
using EmailSender.api.Common.Others.Implementation.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation();
    builder.Services.Configure<EmailSettings>(
        builder.Configuration.GetSection("EmailSettings")
    );

}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

