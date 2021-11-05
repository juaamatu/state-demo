using System.Collections;

namespace Game.RoutedStates.States
{
    public class RootState : IState
    {
        public IEnumerator OnEnter()
        {
            yield break;
        }

        public IEnumerator OnExit()
        {
            yield break;
        }
    }
}