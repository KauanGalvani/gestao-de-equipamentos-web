//builder de um servidor web
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//MVC
builder.Services.AddControllersWithViews();

//Criação da instancia do servidor web
WebApplication app = builder.Build();

// Middlewares - funçõpes que executam em cada chamada que nosso servidor vai receber servido
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();