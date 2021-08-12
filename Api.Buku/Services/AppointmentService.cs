using Api.Buku.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Buku.Services
{
    public class AppointmentService
    {

        private readonly IMongoCollection<Appointment> _appt;

        public AppointmentService(IBukuDatabaseSettings settings)
        {

            settings.BukuCollectionName = "Appointment";
            var settings_ = MongoClientSettings
                .FromConnectionString(settings.ConnectionString);
            var client = new MongoClient(settings_);
            var database = client.GetDatabase(settings.DatabaseName);
            _appt = database.GetCollection<Appointment>(settings.BukuCollectionName);


            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.DatabaseName);

            // _users = database.GetCollection<Users>(settings.BukuCollectionName);
        }


        public async Task<List<Appointment>> Get() =>
          await _appt.Find(x => true).ToListAsync();

        public async Task<Appointment> Get(string id) =>
           await _appt.Find<Appointment>(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Appointment> Create(Appointment a)
        {
            await _appt.InsertOneAsync(a);
            return a;
        }


        //public async Task<Users> AuthLogin(UserLogin users)
        //{
        //    Users UserResults = null;
        //    try
        //    {

        //        UserResults = await _users
        //      .Find<Users>(x => x.EmailAddress == users.Email
        //        && x.Password == users.Password).FirstOrDefaultAsync();

        //    }
        //    catch (Exception E)
        //    {

        //    }
        //    return UserResults;


        //}

        public async void Update(string id, Appointment a) =>
           await  _appt.ReplaceOneAsync(x => x.Id == id, a);

        public async void Remove(Appointment a) =>
           await _appt.DeleteOneAsync(x => x.Id == a.Id);

        public async void Remove(string id) =>
           await  _appt.DeleteOneAsync(x => x.Id == id);
    }
}

