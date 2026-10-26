var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Connects to SchoolApi
builder.Services.AddHttpClient("SchoolApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["SchoolApiUrl"]!);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();