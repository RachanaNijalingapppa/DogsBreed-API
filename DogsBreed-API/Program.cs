var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var dataPath = Path.Combine(AppContext.BaseDirectory, "Data");
if (!Directory.Exists(dataPath))
{
    Directory.CreateDirectory(dataPath);
    var jsonPath = Path.Combine(dataPath, "dogs.json");
    if (!File.Exists(jsonPath))
    {
        await File.WriteAllTextAsync(jsonPath, "[]");
    }
}

// Register your custom service here
builder.Services.AddScoped<DogBreeds.Services.DogBreedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DogBreeds}/{action=Index}/{id?}");

// Redirect root to Home/Index
app.MapGet("/", context =>
{
    context.Response.Redirect("/DogBreeds/Index");
    return Task.CompletedTask;
});


app.Run();
