using Api.Buku.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Buku.Services
{
    public class BukuService
    {

        private readonly IMongoCollection<Users> _users;

        public BukuService(IBukuDatabaseSettings settings)
        {

            settings.BukuCollectionName = "Users";
            var settings_ = MongoClientSettings
                .FromConnectionString(settings.ConnectionString);
            var client = new MongoClient(settings_);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<Users>(settings.BukuCollectionName);


            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.DatabaseName);

            // _users = database.GetCollection<Users>(settings.BukuCollectionName);
        }


        public async Task<List<Users>> Get() =>
          await _users.Find(Users => true).ToListAsync();

        public async Task<Users> Get(string id) =>
           await _users.Find<Users>(users => users.Id == id).FirstOrDefaultAsync();

        public async Task<Users> Create(Users users)
        {
            await _users.InsertOneAsync(users);
            return users;
        }


        public async Task<Users> AuthLogin(UserLogin users)
        {
            Users UserResults = null;
            try
            {

                UserResults = await _users
              .Find<Users>(x => x.EmailAddress == users.Email
                && x.Password == users.Password).FirstOrDefaultAsync();

            }
            catch (Exception E)
            {

            }
            return UserResults;


        }

        public async void Update(string id, Users users) =>
           await  _users.ReplaceOneAsync(users => users.Id == id, users);

        public async void Remove(Users user) =>
           await _users.DeleteOneAsync(Users => Users.Id == Users.Id);

        public async void Remove(string id) =>
           await  _users.DeleteOneAsync(Users => Users.Id == id);
    }
}

