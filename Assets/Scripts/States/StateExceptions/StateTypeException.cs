using System;

namespace Game.States.StateExceptions
{
    public class StateTypeException : Exception
    {
        public StateTypeException() : base() { }
        public StateTypeException(string message) : base(message) { }
        public StateTypeException(string message, Exception inner) : base(message, inner) { }
    }
}