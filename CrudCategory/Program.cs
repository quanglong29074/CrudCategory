using Microsoft.EntityFrameworkCore;
using CrudCategory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CategoryDb>(opt => opt.UseInMemoryDatabase("Category"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();


app.MapGet("/Categorys", async (CategoryDb db) =>
    await db.Categorys.ToListAsync());

app.MapGet("/Categorys/{id}", async (int id, CategoryDb db) =>
    await db.Categorys.FindAsync(id)


        is Category Category
        ? Results.Ok(Category) : Results.NotFound());

app.MapPost("/Categorys", async (Category Category, CategoryDb db) =>
{
    db.Categorys.Add(Category);
    await db.SaveChangesAsync();

    return Results.Created($"/Categorys/{Category.CategoryId}", Category);
});

app.MapPut("/Categorys/{id}", async (int id, Category inputCategory, CategoryDb db) =>
{
    var Category = await db.Categorys.FindAsync(id)

;
    if (Category == null) return Results.NotFound();

    Category.CategoryName = inputCategory.CategoryName;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Categorys/{id}", async (int id, CategoryDb db) =>
{
    if (await db.Categorys.FindAsync(id)

 is Category Category)
    {
        db.Categorys.Remove(Category);
        await db.SaveChangesAsync();
        return Results.Ok(Category);
    }
    return Results.NotFound();
});
app.Run();
