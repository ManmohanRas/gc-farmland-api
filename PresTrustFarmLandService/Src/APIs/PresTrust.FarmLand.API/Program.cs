var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);


var app = builder.Build();
app.AddMiddleware(builder.Environment);

app.MapControllers();
app.Run();
