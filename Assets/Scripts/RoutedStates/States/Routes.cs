using System;
using System.Linq;

namespace Game.RoutedStates.States
{
    /// <summary>
    /// Contains predefined routes that can be pushed to <see cref="StateManager"/>.
    /// </summary>
    public static class Routes
    {
        private static readonly Type[] RootRoute = { typeof(RootState) };
        public static readonly Type[] StartupRoute = RootRoute.Concat(new [] { typeof(StartupState) } ).ToArray();
    }
}
