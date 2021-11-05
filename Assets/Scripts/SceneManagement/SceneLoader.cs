using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.SceneManagement
{
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

        public static IEnumerator LoadSceneAsync(string sceneName)
        {
            return Loader(sceneName);
        }
    }
}