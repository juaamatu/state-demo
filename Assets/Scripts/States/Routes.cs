using System;
using System.Linq;

namespace Game.States
{
    public static class Routes
    {
        private static readonly Type[] RootRoute = { typeof(RootState) };
        public static readonly Type[] StartupRoute = RootRoute.Concat(new [] { typeof(StartupState) } ).ToArray();
    }
}
