using GameStoreApi.Dtos;

namespace GameStoreApi.Endpoints
{
    public static class GameEndpoints
    {
        static private readonly List<GameDto> games = [
            new GameDto()
            {
                Id = 1,
                Name = "Street Fighter II",
                Genre = "Fighting",
                Price = 19.99M,
                ReleaseDate = new DateOnly(1992, 7, 15)
            },
            new GameDto()
            {
                Id = 2,
                Name = "Final Fantasy XVI",
                Genre = "Roleplaying",
                Price = 59.99M,
                ReleaseDate = new DateOnly(2010, 9, 30)
            },
            new GameDto()
            {
                Id = 3,
                Name = "FIFA 23",
                Genre = "Sports",
                Price = 69.99M,
                ReleaseDate = new DateOnly(2022, 9, 27)
            },

        ];


        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("games")
                           .WithParameterValidation();


            // GET /games
            group.MapGet("/", () => games);


            // GET /games/1
            group.MapGet("/{id}", (int id) =>
            {
                var game = games.Find(game => game.Id == id);

                return game is null ? Results.NotFound() : Results.Ok(game);

            }).WithName("GetGame");


            // POST /games
            group.MapPost("/", (CreateGameDto newGame) =>
            {
                GameDto gameDto = new GameDto()
                {
                    Id = games.Count() + 1,
                    Name = newGame.Name,
                    Genre = newGame.Genre,
                    Price = newGame.Price,
                    ReleaseDate = newGame.ReleaseDate,
                };

                games.Add(gameDto);

                return Results.CreatedAtRoute("GetGame", new { id = gameDto.Id }, gameDto);

            });


            // PUT /games
            group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
            {
                var index = games.FindIndex(game => game.Id == id);


                if (index == -1) return Results.NotFound();


                games[index] = new GameDto
                {
                    Id = id,
                    Name = updateGame.Name,
                    Genre = updateGame.Genre,
                    Price = updateGame.Price,
                    ReleaseDate = updateGame.ReleaseDate,
                };

                return Results.NoContent();
            });


            // DELETE /games
            group.MapDelete("/{id}", (int id) =>
            {
                games.RemoveAll(game => game.Id == id);

                return Results.NoContent();
            });

            return group;
        }

    }
}
