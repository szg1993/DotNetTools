using ErrorHandlerMiddleware.Middlewares;

var builder = WebApplication
    .CreateBuilder(args);

builder.Services
    .AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder
    .Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .UseHttpsRedirection()
    .UseAuthorization()
    .UseMiddleware<ExceptionReponseMiddleware>();

app.MapControllers();

app.Run();
