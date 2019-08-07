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
        // Notes Methodsvimplemention.
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



        // Labels Methods start from here. 
        // create Label.
        public void CreateLabel(int NoteID, Label label)
        {
            int LabelID = GetNewLabelID(NoteID);
            label.LabelID = LabelID;
            var filter = Builders<Notes>.Filter.Eq( n => n.NoteID , NoteID);
            var updated = Builders<Notes>.Update.Push( u => u.labels, label);
            noteDbcontext.NotesCollection.FindOneAndUpdate(filter, updated);
        }

        // Auto genrated LabelID.
        public int GetNewLabelID(int NoteID)
        {
            return noteDbcontext.NotesCollection.AsQueryable().Where(n => n.NoteID == NoteID).FirstOrDefault().labels.Max( l => l.LabelID)+1;
        }

        // Get All Labels.
        public ICollection<Label> GetLabels(int NoteID)
        {
            Notes SpecificNote = noteDbcontext.NotesCollection.Find( n => n.NoteID == NoteID).First();
            return SpecificNote.labels;
        }

        // Remove Specific Label from Specific Note.
        public void RemoveLabelByLabelIDandNoteID(int NoteID, int LabelID)
        {
            Notes SpecificNote = noteDbcontext.NotesCollection.Find( n => n.NoteID == NoteID).First();
            Label SpecificLabel = SpecificNote.labels.First( l => l.LabelID == LabelID);

            var filter = Builders<Notes>.Filter.Eq( n => n.NoteID, NoteID);
            var LabelToDelete = Builders<Notes>.Update.Pull( e => e.labels, SpecificLabel);
            noteDbcontext.NotesCollection.FindOneAndUpdate(filter, LabelToDelete);
        }

        // Update a Specific Label in Specific Note.
        public void UpdateLabel(int NoteID, Label label)
        {
            Notes SpecificNote = noteDbcontext.NotesCollection.Find( n => n.NoteID == NoteID).First();
            Label Specificlabel = SpecificNote.labels.First( l => l.LabelID == label.LabelID);

            Specificlabel.Description = label.Description;
            noteDbcontext.NotesCollection.ReplaceOne( n => n.NoteID == SpecificNote.NoteID, SpecificNote);
        }



    }
}