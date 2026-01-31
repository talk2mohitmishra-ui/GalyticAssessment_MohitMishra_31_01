using GalyticAssessment_MohitMishra.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var businessGWPService = new BusinessGWPService();
builder.Services.AddSingleton(businessGWPService);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
 
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"); });
}

var filePath = Path.Combine(app.Environment.ContentRootPath, "DataAccess\\gwpByCountry.csv");
businessGWPService.LoadData(filePath);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
