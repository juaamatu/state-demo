using System;

namespace Game.RoutedStates.StateExceptions
{
    public class EmptyRouteException : Exception
    {
        public EmptyRouteException() : base() { }
        public EmptyRouteException(string message) : base(message) { }
        public EmptyRouteException(string message, Exception inner) : base(message, inner) { }
    }
}