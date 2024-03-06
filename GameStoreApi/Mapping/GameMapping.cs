using GameStoreApi.Dtos;
using GameStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game)
        {
            return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };
        }

        public static Game ToEntity(this UpdateGameDto game, int id)
        {
            return new Game()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };
        }


        public static GameSummaryDto ToGameSummaryDto(this Game game)
        {
            return new GameSummaryDto()
            {
                Id = game.Id,
                Genre = game.Genre!.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                Name = game.Name,
            };
        }

        public static GameDetailsDto ToGameDetailsDto(this Game game)
        {
            return new GameDetailsDto()
            {
                Id = game.Id,
                Genre = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                Name = game.Name,
            };
        }


    }
}
