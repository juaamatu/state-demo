using Game.RoutedStates;
using UnityEngine;

public class TestStateManager : MonoBehaviour
{
    public StateManager StateManager { get; private set; }
    
    public void Awake()
    {
        StateManager = new StateManager(this);
        DontDestroyOnLoad(gameObject);
    }
}
