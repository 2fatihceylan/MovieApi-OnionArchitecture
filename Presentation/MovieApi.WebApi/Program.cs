using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieApi.Persistance.Context;
using MovieApi.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



//Swagger eklenmesi //Extensions dizini altýndaki SwaggerExtensions.cs dosyasýndaki metodu kullanarak ekliyoruz
builder.Services.AddSwaggerServices();


builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



//CQRS
builder.Services.AddApplicationServices();

//identity
builder.Services.AddIdentityServices();

//MediatR
builder.Services.AddMediatRServices();

//tüm extensionslarý tek seferde ekleyebilirdik ama koda sonra bakýnca neyin ne iþe yaradýðýný anlamak zor olurdu
//builder.Services.AddSwaggerServices().AddApplicationServices().AddIdentityServices().AddMediatRServices();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();


    //Swagger eklenmesi
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json","My Api V1");
    });
}

//browsarda swagger açýlmasý için
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
