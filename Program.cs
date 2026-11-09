using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services toevoegen (voor Build)
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Laag 1: database
builder.Services.AddDbContext<PortfolioDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Portfolio")));

// Laag 2: services
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<BlogpostService>();

var app = builder.Build();
//middleware na build
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
