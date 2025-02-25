using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("people");
builder.Services.AddKeyedSingleton<IPeopleService, People2Service>("people2");

//inyectando dependencia mediante el uso de distintos servicios
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");



builder.Services.AddScoped<IPostsService, PostsService>();

builder.Services.AddHttpClient<IPostsService, PostsService>(c=>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});
//conexion entity framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));

});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
