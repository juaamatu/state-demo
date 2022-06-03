using System.Collections;

namespace Game.RoutedStates.States
{
    /// <summary>
    /// General interface for all states.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Called when state is added to the stack.
        /// </summary>
        /// <returns></returns>
        public IEnumerator OnEnter();
        /// <summary>
        /// Called when state is removed from the stack.
        /// </summary>
        /// <returns></returns>
        public IEnumerator OnExit();
    }
}