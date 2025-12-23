var builder = WebApplication.CreateBuilder(args);

// MVC + API controllers
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger should be enabled in ALL environments (assignment requirement)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ThinkBridge API v1");
    c.RoutePrefix = "swagger"; // https://host/swagger
});

// Render / Docker port binding (IMPORTANT)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Enable CORS
app.UseCors("AllowUI");

app.UseAuthorization();

// API routes
app.MapControllers();

// MVC default route (safe to keep)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();