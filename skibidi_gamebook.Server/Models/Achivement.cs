using skibidi_gamebook.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace skibidi_gamebook.Server.Models
{
    public class Achivement
    {
        public int Id { get; set; } // PK
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }


public static class AchivementEndpoints
{
	public static void MapAchivementEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Achivement").WithTags(nameof(Achivement));

        group.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Achivements.ToListAsync();
        })
        .WithName("GetAllAchivements")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Achivement>, NotFound>> (int id, AppDbContext db) =>
        {
            return await db.Achivements.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Achivement model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAchivementById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Achivement achivement, AppDbContext db) =>
        {
            var affected = await db.Achivements
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, achivement.Id)
                  .SetProperty(m => m.Name, achivement.Name)
                  .SetProperty(m => m.Description, achivement.Description)
                  .SetProperty(m => m.Img, achivement.Img)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAchivement")
        .WithOpenApi();

        group.MapPost("/", async (Achivement achivement, AppDbContext db) =>
        {
            db.Achivements.Add(achivement);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Achivement/{achivement.Id}",achivement);
        })
        .WithName("CreateAchivement")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AppDbContext db) =>
        {
            var affected = await db.Achivements
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAchivement")
        .WithOpenApi();
    }
}}
