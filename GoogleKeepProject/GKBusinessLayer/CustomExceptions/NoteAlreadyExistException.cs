using System;

namespace GKBusinessLayer.CustomExceptions
{
    /// <summary>
    /// Custom Exception classes for Notes.
    /// </summary>
    public class NoteAlreadyExistException : ApplicationException
    {
        public NoteAlreadyExistException() { }
        public NoteAlreadyExistException(string Message) : base(Message) { }
    }
}
