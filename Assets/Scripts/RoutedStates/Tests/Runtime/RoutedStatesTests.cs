using System;
using System.Collections;
using System.Threading.Tasks;
using Game.RoutedStates;
using Game.RoutedStates.States;
using Game.Utils;
using NUnit.Framework;
using RoutedStates.Tests;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

public class RoutedStatesTests
{
    private TestStateManager stateManagerRunner;
    private StateManager stateManager => stateManagerRunner.StateManager;
    
    [SetUp]
    public void Setup()
    {
        stateManagerRunner = new GameObject().AddComponent<TestStateManager>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(stateManagerRunner.gameObject);
    }
    
    [Test]
    public void States_can_be_changed()
    {
        stateManager.SetRoute(Routes.StartupRoute);
        AssertCurrentRouteTopStateType(typeof(StartupState));
    }
    
    [Test]
    public void Empty_route_cant_be_supplied()
    {
        Assert.Throws<ArgumentException>(() => stateManager.SetRoute(new Type[] { }));
    }
    
    [UnityTest]
    public IEnumerator Common_states_are_preserved()
    {
        Type[] firstRoute = new Type[] { typeof(RootState), typeof(StartupState), typeof(TestState), typeof(StartupState) };
        Type[] secondRoute = new Type[] { typeof(RootState), typeof(StartupState), typeof(TestState) };
        yield return AsyncUtils.YieldUntilCompletion(stateManager.SetRoute(firstRoute));
        IState[] instances = new[]
        {
            stateManager.CurrentRoute[0],
            stateManager.CurrentRoute[1],
            stateManager.CurrentRoute[2]
        };
        
        yield return AsyncUtils.YieldUntilCompletion(stateManager.SetRoute(secondRoute));
        for(int i = 0; i < instances.Length; i++)
        {
            Assert.AreEqual(instances[i], stateManager.CurrentRoute[i]);
        }
    }

    private void AssertCurrentRouteTopStateType(Type type)
    {
        Assert.IsTrue(stateManager.CurrentRoute[stateManager.CurrentRoute.Count - 1].GetType() == type);
    }
}
