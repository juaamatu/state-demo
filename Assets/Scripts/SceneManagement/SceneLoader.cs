using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.SceneManagement
{
    /// <summary>
    /// Helper that return a IEnumerator that yields until scene has been loaded.
    /// </summary>
    public static class SceneLoader
    {
        private static IEnumerator Loader(string sceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = true;
            while (!operation.isDone)
            {
                yield return null;
            }
        }

        /// <summary>
        /// Helper that return a IEnumerator that yields until scene has been loaded.
        /// </summary>
        /// <param name="sceneName">Name of the scene to load.</param>
        /// <returns></returns>
        public static IEnumerator LoadSceneAsync(string sceneName)
        {
            return Loader(sceneName);
        }
    }
}