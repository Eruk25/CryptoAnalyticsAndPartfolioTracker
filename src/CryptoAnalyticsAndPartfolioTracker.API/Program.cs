using CryptoAnalyticsAndPartfolioTracker.API.Extensions;
using CryptoAnalyticsAndPartfolioTracker.Application.Extensions;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
