using EmployeeApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "TBD",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact {
            Name = "John Doe",
            Email = "john@xyzmail.com",
            Url = new Uri("https://example.com")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense {
            Name = "License Terms",
            Url = new Uri("https://example.com")
        }
    });
});

builder.Services.AddScoped<CustomAuthFilter>();

builder.Services.AddControllers(options => {
    options.Filters.Add<CustomExceptionFilter>();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
