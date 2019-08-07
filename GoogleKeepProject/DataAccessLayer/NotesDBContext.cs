using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DataAccessLayer
{
    public class NotesDBConText
    {

        MongoClient mongoClient;
        IMongoDatabase mongoDatabase;

        public NotesDBConText() { }

        public NotesDBConText(IConfiguration configuration)
        {
            mongoClient = new MongoClient(configuration.GetSection("MongoDB:server").Value);
            mongoDatabase = mongoClient.GetDatabase(configuration.GetSection("MongoDB:database").Value);
        }

        public IMongoCollection<Notes> NotesCollection => mongoDatabase.GetCollection<Notes>("Notescollection");

        //public IMongoCollection<Label> LabelCollection => mongoDatabase.GetCollection<Label>("Lablescollection");

    }
}
