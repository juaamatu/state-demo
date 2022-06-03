using System.Collections;
using Game.SceneManagement;

namespace Game.RoutedStates.States
{
    /// <summary>
    /// State that loads startup scene on enter.
    /// </summary>
    public class StartupState : IState
    {
        private const string StartupScene = "Startup";

        /// <inheritdoc />
        public IEnumerator OnEnter()
        {
            yield return SceneLoader.LoadSceneAsync(StartupScene);
        }

        /// <inheritdoc />
        public IEnumerator OnExit()
        {
            yield break;
        }
    }
}