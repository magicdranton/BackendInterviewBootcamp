using DotnetNewWebapi.Middleware;
using DotnetNewWebapi.Services;
using DotnetNewWebapi.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Configure<CApplicationOptions>(builder.Configuration.GetSection(CApplicationOptions.SectName));
//builder.Services.Configure<CExternalApiOptions>(builder.Configuration.GetSection(CExternalApiOptions.SectName));

builder.Services.AddOptions<CApplicationOptions>().Bind(builder.Configuration.GetSection(CApplicationOptions.SectName)).ValidateDataAnnotations().ValidateOnStart();
builder.Services.AddOptions<CExternalApiOptions>().Bind(builder.Configuration.GetSection(CExternalApiOptions.SectName)).ValidateDataAnnotations().ValidateOnStart();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<ISingletonService, CSingletonService>();
builder.Services.AddScoped<IScopedService, CScopedService>();
builder.Services.AddScoped<IWeatherService, CWeatherService>();
builder.Services.AddTransient<ITransientService, CTransientService>();
builder.Services.AddHostedService<CSomeBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseCExceptionHandling();

app.UseCRequestTiming();

app.MapControllers();

app.Run();
