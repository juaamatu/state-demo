using System.Collections;
using Game.RoutedStates.States;

namespace RoutedStates.Tests
{
    public class TestState : IState
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