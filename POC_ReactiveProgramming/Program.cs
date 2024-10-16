using POC_ReactiveProgramming.Hubs;
using POC_ReactiveProgramming.Implementation.FenService;
using POC_ReactiveProgramming.Implementation.Lichess;
using POC_ReactiveProgramming.Implementation.Lichess.Observables;
using POC_ReactiveProgramming.Interface.FanService;
using POC_ReactiveProgramming.Interface.Lichess;
using POC_ReactiveProgramming.Interface.Lichess.Observables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddScoped<ILichessQuery, LichessQuery>();
builder.Services.AddScoped<IObservableLichessService, ObservableLichessService>();
builder.Services.AddScoped<IFenService, FenService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChessHub>("/chessHub");

app.Run();
