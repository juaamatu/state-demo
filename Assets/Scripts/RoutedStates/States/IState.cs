using System.Collections;

namespace Game.RoutedStates.States
{
    public interface IState
    {
        public IEnumerator OnEnter();
        public IEnumerator OnExit();
    }
}