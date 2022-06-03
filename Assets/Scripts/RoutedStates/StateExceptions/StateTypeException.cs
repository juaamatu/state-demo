using System;

namespace Game.RoutedStates.StateExceptions
{
    /// <summary>
    /// Exception thrown when some state is not of type <see cref="IState"/>.
    /// </summary>
    public class StateTypeException : Exception
    {
        public StateTypeException() : base() { }
        public StateTypeException(string message) : base(message) { }
        public StateTypeException(string message, Exception inner) : base(message, inner) { }
    }
}