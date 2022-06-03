using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Game.RoutedStates.States;
using Game.RoutedStates.StateExceptions;

namespace Game.RoutedStates
{
    public class StateManager
    {
        public IReadOnlyList<IState> CurrentRoute => currentRoute.AsReadOnly();

        private readonly List<IState> currentRoute;
        private readonly MonoBehaviour controller;

        private IEnumerator Router(Type[] commonRoute, Type[] route, TaskCompletionSource<bool> taskCompletionSource)
        {
            while (currentRoute.Count > commonRoute.Length)
            {
                yield return currentRoute[currentRoute.Count - 1].OnExit();
                currentRoute.RemoveAt(currentRoute.Count - 1);
            }

            for (int i = commonRoute.Length; i < route.Length; i++)
            {
                if (!typeof(IState).IsAssignableFrom(route[i]))
                {
                    throw new StateTypeException();
                }
                
                IState state = (IState)Activator.CreateInstance(route[i]);
                currentRoute.Add(state);
                yield return state.OnEnter();
            }
            taskCompletionSource.SetResult(true);
        }

        public Task SetRoute(Type[] route)
        {
            if (route.Length == 0)
            {
                throw new ArgumentException("Route can't be empty.", nameof(route));
            }

            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            Type[] commonRoute = CommonRouteSolver.FindCommonRoute(currentRoute.Select(x => x.GetType()).ToArray(), route);
            controller.StartCoroutine(Router(commonRoute, route, taskCompletionSource));
            return taskCompletionSource.Task;
        }

        public StateManager(MonoBehaviour monoBehaviour)
        {
            currentRoute = new List<IState>(new IState[] { new RootState() });
            controller = monoBehaviour;
        }
    }
}
