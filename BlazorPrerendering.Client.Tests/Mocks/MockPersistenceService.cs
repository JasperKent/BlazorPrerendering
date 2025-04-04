using BlazorPrerendering.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorPrerendering.Client.Tests.Mocks;

internal class MockPersistenceService : IPersistenceService
{
    private readonly List<Func<Task>> _actions = [];

    public async Task<PersistingComponentStateSubscription> Build()
    {
        foreach (var action in _actions)
        {
            await action();
        }

        return new PersistingComponentStateSubscription();
    }

    public IPersistenceService Register<T>(Action<T> assignment, Func<Task<T>> creation)
    {
        _actions.Add(async () => assignment(await creation()));

        return this;
    }
}
