using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using oceane_survey_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Ajouter le DbContext
builder.Services.AddDbContext<SurveyContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SurveyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;"));

// Enregistrer les services nécessaires
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddControllers();

// 📌 Ajouter Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Survey API",
        Version = "v1",
        Description = "API pour gérer les surveys et leurs questions.",
        Contact = new OpenApiContact
        {
            Name = "Support Dev",
            Email = "support@example.com",
            Url = new Uri("https://example.com")
        }
    });
});

var app = builder.Build();

// 📌 Activer Swagger uniquement en mode développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Survey API v1");
        options.RoutePrefix = string.Empty; // Permet d’accéder à Swagger via "/"
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
