using ASPNET_API_With_GPT.Extensions;

var appName = "ASP.NET Web API with ChatGPT";
var appVersion = "v1";

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilog(builder.Configuration, appName);
builder.AddChatGpt();

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddSwagger(builder.Configuration, appName, appVersion);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDoc(appName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
