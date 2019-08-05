using System;

namespace GKBusinessLayer.CustomExceptions
{
    /// <summary>
    /// Custom Exception classes for Labels.
    /// </summary>
    public class LabelAlreadyExistsException : ApplicationException
    {
        public LabelAlreadyExistsException() { }
        public LabelAlreadyExistsException(string Message) : base(Message) { }
    }
}
