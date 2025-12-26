using Application;
using Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddCredentialValidator(builder.Configuration);
builder.Services.AddApplication();

WebApplication app = builder.Build();
app.MapControllers();
app.Run();