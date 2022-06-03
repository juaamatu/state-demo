using System;

namespace Game.RoutedStates.StateExceptions
{
    /// <summary>
    /// Exception thrown when some route has no states defined in it.
    /// </summary>
    public class EmptyRouteException : Exception
    {
        public EmptyRouteException() : base() { }
        public EmptyRouteException(string message) : base(message) { }
        public EmptyRouteException(string message, Exception inner) : base(message, inner) { }
    }
}