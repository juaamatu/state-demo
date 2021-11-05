using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.States.StateExceptions;
using UnityEngine;

namespace Game.States.StateManager
{
    public class StateManager
    {
        private readonly Stack<IState> currentRoute;
        private readonly MonoBehaviour controller;

        private IEnumerator Router(Type[] commonRoute, Type[] route)
        {
            while (currentRoute.Count > commonRoute.Length)
            {
                yield return currentRoute.Pop().OnExit();
            }

            for (int i = commonRoute.Length; i < route.Length; i++)
            {
                if (!typeof(IState).IsAssignableFrom(route[i]))
                {
                    throw new StateTypeException();
                }
                
                IState state = (IState)Activator.CreateInstance(route[i]);
                currentRoute.Push(state);
                yield return state.OnEnter();
            }
        }

        public void SetRoute(Type[] route)
        {
            Type[] commonRoute = CommonRouteSolver.FindCommonRoute(currentRoute.Select(x => x.GetType()).ToArray(), route);
             controller.StartCoroutine(Router(commonRoute, route));
        }

        public StateManager(MonoBehaviour monoBehaviour)
        {
            currentRoute = new Stack<IState>(new IState[] { new RootState() });
            controller = monoBehaviour;
        }
    }
}