using AgendamentoMvc.Business.Service;
using AgendamentoMvc.Business.Service.Interface;
using AgendamentoMvc.Data.Context;
using AgendamentoMvc.Data.Repository;
using AgendamentoMvc.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMedicosService, MedicosService>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddDbContext<AgendamentoMvcDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDb"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
