using System.Collections;
using Game.SceneManagement;

namespace Game.States
{
    public class StartupState : IState
    {
        private const string StartupScene = "Startup";

        public IEnumerator OnEnter()
        {
            yield return SceneLoader.LoadSceneAsync(StartupScene);
        }

        public IEnumerator OnExit()
        {
            yield break;
        }
    }
}