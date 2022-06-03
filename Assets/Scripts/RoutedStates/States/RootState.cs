using System.Collections;

namespace Game.RoutedStates.States
{
    /// <summary>
    /// Base state that always has to be the bottom state in the stack
    /// </summary>
    public class RootState : IState
    {
        /// <inheritdoc />
        public IEnumerator OnEnter()
        {
            yield break;
        }

        /// <inheritdoc />
        public IEnumerator OnExit()
        {
            yield break;
        }
    }
}