using EmailSender.api;
using EmailSender.api.Common.Others.Implementation.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors(options => {
        options.AddPolicy("AllowSpecificOrigin",
        builder => 
        {
            builder.WithOrigins()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    });

    builder.Services
        .AddPresentation();
    builder.Services.Configure<EmailSettings>(
        builder.Configuration.GetSection("EmailSettings")
    );

}

var app = builder.Build();
{
    app.UseCors();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

