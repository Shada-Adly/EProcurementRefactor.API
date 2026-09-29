using EProcurementRefactor.Application.Extenions;
using EProcurementRefactor.Infrastructure.Extenions;
using static EProcurementRefactor.API.Middlewares.GlobalExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfarstructureServices(builder.Configuration);

builder.Services.AddApplicationService();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalException>();

app.MapControllers();

app.Run();
