using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GKBusinessLayer
{
    public interface IKeepNoteService
    {
        // Notes Methods Starts Here.
        void CreateNote(Notes notes);

        bool RemoveNote(int NoteID);

        bool UpdateNote(int NoteID, Notes notes);

        Notes GetNotesByID(int NoteID);

        List<Notes> GetAllNotes();


        // Labels Methods.
        ICollection<Label> GetLabels(int NoteID);

        void CreateLabel(int NoteID, Label label);

        void UpdateLabel(int LabelID, Label label);

        void RemoveLabel(int NoteID, int LabelID);
    }
}
