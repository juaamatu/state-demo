using UnityEngine;
using Game.RoutedStates;
using Game.RoutedStates.States;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            StateManager stateManager = new StateManager(this);
            stateManager.SetRoute(Routes.StartupRoute);
        }
    }
}