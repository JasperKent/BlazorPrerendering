using Microsoft.AspNetCore.Components;

namespace BlazorPrerendering.Client.Services
{
    public interface IPersistenceService
    {
        Task<PersistingComponentStateSubscription> Build();
        IPersistenceService Register<T>(Action<T> assignment, Func<Task<T>> creation);
    }
}