using BlazorPrerendering.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorPrerendering.Client.Services
{
    public class PersistenceService : IPersistenceService
    {
        private readonly PersistentComponentState _state;
        private readonly PersistingComponentStateSubscription _subscription;
        private readonly List<Func<Task>> _registrations = [];
        private readonly Dictionary<string, object?> _data = [];

        private int _nextKey;

        public PersistenceService(PersistentComponentState state)
        {
            _state = state;
            _subscription = _state.RegisterOnPersisting(PersistData);
        }

        private Task PersistData()
        {
            foreach (var item in _data)
            {
                _state.PersistAsJson(item.Key, item.Value);
            }

            return Task.CompletedTask;
        }

        public IPersistenceService Register<T>(Action<T> assignment, Func<Task<T>> creation)
        {
            _registrations.Add(async () =>
            {
                var key = $"Key_{++_nextKey}";

                _state.TryTakeFromJson(key, out T? data);

                data ??= await creation();

                assignment(data);

                _data[key] = data;
            });

            return this;
        }

        public async Task<PersistingComponentStateSubscription> Build()
        {
            await Task.WhenAll(_registrations.Select(r => r()));

            return _subscription;
        }
    }
}
