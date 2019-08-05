using Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class NotesImplemention : IKeepNotes
    {

        // create a refrence of noteDBContext class and instantiate inside constructor.
        private readonly NotesDBConText noteDbcontext;

        public NotesImplemention(NotesDBConText text)
        {
            noteDbcontext = text;
        }


        // this is implementation of all the methods of IkeepNotes.
        // Create a new Note.
        public void CreateNote(Notes notes)
        {
            noteDbcontext.NotesCollection.InsertOne(notes);
        }


        // Get all the notes.
        public List<Notes> GetAllNotes()
        {
            return noteDbcontext.NotesCollection.Find( _ => true).ToList();
        }


        // Get the note by specific ID.
        public Notes GetNotesByID(int NoteID)
        {
            return noteDbcontext.NotesCollection.Find( n => n.NoteID == NoteID).FirstOrDefault();
        }


        // Remove the note by spesific ID.
        public bool RemoveNote(int NoteID)
        {
            var selectnote = noteDbcontext.NotesCollection.DeleteOne( n => n.NoteID == NoteID);
            return selectnote.IsAcknowledged && selectnote.DeletedCount > 0;
        }

         
        // Update the pre existing note.
        public bool UpdateNote(int NoteID, Notes notes)
        {
            var filter = Builders<Notes>.Filter.Where( b => b.NoteID == NoteID);
            var Result = noteDbcontext.NotesCollection.ReplaceOne(filter, notes);
            return Result.IsAcknowledged && Result.ModifiedCount > 0;

        }
    }
}