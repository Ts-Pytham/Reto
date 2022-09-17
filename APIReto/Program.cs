

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000");
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRepositories()
                .AddBusiness();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

new EnvLoader()
               .AddEnvFile("info.env")
              .Load();


var settings = new EnvBinder().Bind<AppSettings>();
builder.Services.AddSingleton(settings);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(settings.ConnectionString);
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
}

    // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
