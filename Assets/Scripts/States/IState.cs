using System.Collections;

namespace Game.States
{
    public interface IState
    {
        public IEnumerator OnEnter();
        public IEnumerator OnExit();
    }
}