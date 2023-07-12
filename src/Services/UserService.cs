using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SCurveProject.Entities;
using SCurveProject.settings;

namespace SCurveProject.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(MainDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _userCollection = database.GetCollection<User>(databaseSettings.UserCollection);
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userCollection.Find(_ => true).ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> CreateUser(CreateUserModel userModel)
        {
            var user = new User
            {
                Username = userModel.Username,
                Password = userModel.Password,
                Role = userModel.Role
            };

            await _userCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<User> UpdateUser(string id, User user)
        {
            var userupdate = new User
            {
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };

            await _userCollection.ReplaceOneAsync(u => u.Id == id, user);
            return user;
        }

        public async Task<int> DeleteUser(string id)
        {
            await _userCollection.DeleteOneAsync(u => u.Id == id);
            return 1;
        }
    }
}