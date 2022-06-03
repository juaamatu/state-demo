using System.Collections;
using System.Threading.Tasks;

namespace Game.Utils
{
    public static class AsyncUtils
    {
        public static IEnumerator YieldUntilCompletion(Task task)
        {
            while (!task.IsCompleted)
            {
                yield return null;
            }
        }
    }
}
