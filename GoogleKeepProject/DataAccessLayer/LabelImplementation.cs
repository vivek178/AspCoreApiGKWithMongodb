using Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class LabelImplementation : IKeepLabel
    {


        // create a refrence of noteDBContext class and instantiate inside constructor.
        private readonly NotesDBConText noteDbcontext;

        public LabelImplementation(NotesDBConText text)
        {
            noteDbcontext = text;
        }


        // this is implementation of all the methods of IkeepNotes.
        // Create a new Label.
        public void CreateLabel(Label label)
        {
            noteDbcontext.LabelCollection.InsertOne(label);
        }


        // Get all List of Label.
        public List<Label> GetLabels()
        {
            return noteDbcontext.LabelCollection.Find( _ => true).ToList();
        }


        // Remove a specific Label.
        public bool RemoveLabel(int LabelID)
        {
            var selectnote = noteDbcontext.LabelCollection.DeleteOne(n => n.LabelID == LabelID);
            return selectnote.IsAcknowledged && selectnote.DeletedCount > 0;
        }


        // Update a specific label.
        public bool UpdateLabel(int LabelID, Label label)
        {
            var filter = Builders<Label>.Filter.Where(b => b.LabelID == LabelID);
            var Result = noteDbcontext.LabelCollection.ReplaceOne(filter, label);
            return Result.IsAcknowledged && Result.ModifiedCount > 0;
        }
    }
}
