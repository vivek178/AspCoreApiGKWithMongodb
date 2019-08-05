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

        public IMongoCollection<Label> LabelCollection => mongoDatabase.GetCollection<Label>("Lablescollection");


        //public NotesDBConText(DbContextOptions<NotesDBConText> options) : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // defining primary key to NoteId.
        //    modelBuilder.Entity<Notes>().HasKey( n => new { n.NoteID});

        //    // defining primary key to LableID.
        //    modelBuilder.Entity<Label>().HasKey( l => new { l.LabelID});
        //}

        //// Dbset for Notes and Labels class.
        //public DbSet<Notes> notes { get; set; }
        //public DbSet<Label> labels { get; set; }
    }
}
