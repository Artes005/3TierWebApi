using Data.Entities;
using Data.Functions;
using Data.Interfaces;

namespace Business.UserLogic
{
    public class UserLogic
    {
        private IRepository<User> _userFunctions = new UserFunctions();

        public async Task<bool> CreateUserAsync(string username, int positionId)
        {
            if (await GetUserByName(username) != null)
                throw new Exception($"User {username} already exists!");

            try
            {
                User user = new()
                {
                    Username = username,
                    PositionRefId = positionId
                };


                var result = await _userFunctions.Create(user);
                return result.Id > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = await _userFunctions.GetAll();

            return users;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            User? user = await _userFunctions.GetById(userId);

            return user;
        }

        public async Task<bool> UpdateUserAsync(int userId, string username, int userPosition)
        {

            User? user = await _userFunctions.GetById(userId);

            if (user == null) //user not exists
                return false;

            //search existing user with a same name
            User? userDb = await GetUserByName(username);
            if (userDb != null // user with a same name found
                && userDb.Id != userId) //exclude name check for self
                throw new Exception($"User {username} already exists!");

            try
            {
                //update user fields
                user.Username = username;
                user.PositionRefId = userPosition;

                _userFunctions.Update(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {

            User? user = await _userFunctions.GetById(userId);

            if (user == null) //user not exists
                return false;

            try
            {
                _userFunctions.Delete(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<User?> GetUserByName(string userName)
        {
            User? user = (await _userFunctions.GetAll()).Where(x => x.Username == userName).FirstOrDefault();

            return user;
        }
    }
}
