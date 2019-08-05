using System;

namespace GKBusinessLayer.CustomExceptions
{
    /// <summary>
    /// Custom Exception classes for Labels.
    /// </summary>
    public class LabelNotFoundExeception : ApplicationException
    {
        public LabelNotFoundExeception() { }
        public LabelNotFoundExeception(string Message) : base(Message) { }
    }
}
