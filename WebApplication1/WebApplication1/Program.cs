using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using LibraryBookService.ActionFilters;
using LibraryBookService.Data;
using LibraryBookService.Repositories;
using LibraryBookService.Repositories.Interface;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers()
            .AddFluentValidation(
            c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

        builder.Services.AddMvc(options =>
                options.Filters.Add<ValidationFilterAttribute>()
                );

        builder.Services.AddScoped<ValidationFilterAttribute>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddDbContext<BooksDbContext>(options =>
            options.UseInMemoryDatabase("Library"));
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<BooksDbContext>();
            BooksDbContextSeed.Seed(services);
        }


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
    }
}