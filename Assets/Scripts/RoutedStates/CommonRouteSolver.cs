using System;
using System.Collections.Generic;
using Game.RoutedStates.States;
using Game.RoutedStates.StateExceptions;

namespace Game.RoutedStates
{
    /// <summary>
    /// Class that solves common route between two routes.
    /// </summary>
    internal static class CommonRouteSolver
    {
        private static readonly List<Type> solverList = new List<Type>();

        /// <summary>
        /// Determines the common route between two routes and returns it.
        /// </summary>
        /// <param name="route1">First route to check.</param>
        /// <param name="route2">Second route to check.</param>
        /// <returns>Route that contains the common states of both route1 and route2.</returns>
        /// <exception cref="EmptyRouteException"></exception>
        internal static Type[] FindCommonRoute(Type[] route1, Type[] route2)
        {
            if (route1.Length == 0 || route2.Length == 0)
            {
                throw new EmptyRouteException();
            }
            
            solverList.Clear();
            solverList.Add(typeof(RootState));
            for (int i = 1; i < route1.Length; i++)
            {
                if (route2.Length == i || route1[i] != route2[i])
                {
                    break;
                }
                solverList.Add(route1[i]);
            }
            return solverList.ToArray();
        }
    }
}