using GameStoreApi.Data;
using GameStoreApi.Dtos;
using GameStoreApi.Entities;
using GameStoreApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Endpoints
{
    public static class GameEndpoints
    {
        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("games")
                           .WithParameterValidation();


            // GET /games
            group.MapGet("/", async (GameStoreContext dbContext) =>
            {
                var games = await dbContext.Games
                                     .Include(game => game.Genre)
                                     .Select(game => game.ToGameSummaryDto())
                                     .AsNoTracking().ToListAsync();

                return Results.Ok(games);
            }).RequireAuthorization();


            // GET /games/1
            group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                var game = await dbContext.Games
                                          .Include(game => game.Users)
                                          .FirstOrDefaultAsync(game => game.Id == id);

                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());

            }).WithName("GetGame").RequireAuthorization("Admin");


            // POST /games
            group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();

                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game.ToGameDetailsDto());
            }).RequireAuthorization("Admin");


            // PUT /games
            group.MapPut("/{id}", async (int id, UpdateGameDto updateGame, GameStoreContext dbContext) =>
            {
                var existingame = await dbContext.Games.FindAsync(id);


                if (existingame == null) return Results.NotFound();


                dbContext.Entry(existingame)
                          .CurrentValues
                          .SetValues(updateGame.ToEntity(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }).RequireAuthorization("Admin");


            // DELETE /games
            group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games
                         .Where(game => game.Id == id)
                         .ExecuteDeleteAsync();

                return Results.NoContent();
            }).RequireAuthorization("Admin");

            return group;
        }

    }
}
