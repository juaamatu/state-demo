using UnityEngine;
using Game.States;
using Game.States.StateManager;

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