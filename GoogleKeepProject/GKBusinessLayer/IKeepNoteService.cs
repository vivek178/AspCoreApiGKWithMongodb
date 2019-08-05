using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GKBusinessLayer
{
    public interface IKeepNoteService
    {
        void CreateNote(Notes notes);

        bool RemoveNote(int NoteID);

        bool UpdateNote(int NoteID, Notes notes);

        Notes GetNotesByID(int NoteID);

        List<Notes> GetAllNotes();
    }
}
