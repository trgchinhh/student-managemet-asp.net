var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/random",() => {
    Random random = new Random();
    return random.Next(1, 1001);
});

app.Run();