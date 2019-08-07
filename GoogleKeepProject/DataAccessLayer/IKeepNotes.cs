using Entities;
using System.Collections.Generic;

namespace DataAccessLayer
{
    /// <summary>
    /// Inteface for Accessing properties of Notes class.
    /// </summary>
    public interface IKeepNotes
    {
        // This methods is for notes.
        void CreateNote(Notes notes);

        bool RemoveNote(int NoteID);

        bool UpdateNote(int NoteID, Notes notes);

        Notes GetNotesByID(int NoteID);

        List<Notes> GetAllNotes();


        // this  method is for labels.
        ICollection<Label> GetLabels(int NoteID);

        void CreateLabel(int NoteID, Label label);

        void UpdateLabel(int LabelID, Label label);

        void RemoveLabelByLabelIDandNoteID(int NoteID, int LabelID);
    }
}
