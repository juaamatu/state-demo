using System.Collections;
using System.Threading.Tasks;

namespace Game.Utils
{
    /// <summary>
    /// Utilities to work with async problems.
    /// </summary>
    public static class AsyncUtils
    {
        /// <summary>
        /// Yields until task is completed.
        /// </summary>
        /// <param name="task">Task that is awaited.</param>
        /// <returns></returns>
        public static IEnumerator YieldUntilCompletion(Task task)
        {
            while (!task.IsCompleted)
            {
                yield return null;
            }
        }
    }
}
