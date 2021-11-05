using System;

namespace Game.States.StateExceptions
{
    public class EmptyRouteException : Exception
    {
        public EmptyRouteException() : base() { }
        public EmptyRouteException(string message) : base(message) { }
        public EmptyRouteException(string message, Exception inner) : base(message, inner) { }
    }
}