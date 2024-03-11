using GameStoreApi.Dtos;
using GameStoreApi.Entities;

namespace GameStoreApi.Mapping
{
    public static class UserMapping
    {
        public static UserDto ToUserDto (this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
            };
        }

        public static List<UserDto> ToListUserDto (this List<User>? usersList)
        {
            List<UserDto> usersListDto = [];

            if (usersList == null) return usersListDto;

            usersList.ForEach(user =>
            {
                usersListDto.Add(user.ToUserDto());
            });

            return usersListDto;
        }
    }
}
