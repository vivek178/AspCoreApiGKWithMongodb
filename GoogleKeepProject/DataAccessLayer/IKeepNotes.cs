using Entities;
using System.Collections.Generic;

namespace DataAccessLayer
{
    /// <summary>
    /// Inteface for Accessing properties of Notes class.
    /// </summary>
    public interface IKeepNotes
    {
        void CreateNote(Notes notes);

        bool RemoveNote(int NoteID);

        bool UpdateNote(int NoteID, Notes notes);

        Notes GetNotesByID(int NoteID);

        List<Notes> GetAllNotes();
    }
}
