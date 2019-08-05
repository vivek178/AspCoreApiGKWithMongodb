using System;

namespace GKBusinessLayer.CustomExceptions
{
    /// <summary>
    /// Custom Exception classes for Notes.
    /// </summary>
    public class NotesNotFoundException : ApplicationException
    {
        public NotesNotFoundException() { }
        public NotesNotFoundException( string message) : base(message) { }
    }
}
