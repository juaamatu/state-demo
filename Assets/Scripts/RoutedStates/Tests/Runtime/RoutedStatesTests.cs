using System;
using System.Threading.Tasks;
using Game.RoutedStates;
using Game.RoutedStates.States;
using NUnit.Framework;
using RoutedStates.Tests;
using UnityEngine;
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
        AssertStateManagerType(typeof(StartupState));
    }
    
    [Test]
    public void Empty_route_cant_be_supplied()
    {
        Assert.Throws<ArgumentException>(() => stateManager.SetRoute(new Type[] { }));
    }
    
    [Test]
    public async Task Common_states_are_preserved()
    {
        Type[] firstRoute = new Type[] { typeof(RootState), typeof(StartupState), typeof(TestState), typeof(StartupState) };
        Type[] secondRoute = new Type[] { typeof(RootState), typeof(StartupState), typeof(TestState) };
        await stateManager.SetRoute(firstRoute);
        await stateManager.SetRoute(secondRoute);
        Assert.IsTrue(true);
    }

    private void AssertStateManagerType(Type type)
    {
        Assert.IsTrue(stateManager.CurrentRoute.Peek().GetType() == type);
    }
}
