using System;
using System.Collections.Generic;

namespace SimpleEventBus
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<ISubscription<IEvent>>> subscriptions;

        public EventBus()
        {
            subscriptions = new Dictionary<Type, List<ISubscription<IEvent>>>();
        }

        public void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
        {
            if (!subscriptions.ContainsKey(typeof(TEvent)))
            {
                subscriptions.Add(typeof(TEvent), new List<ISubscription<IEvent>>());
            }

            subscriptions[typeof(TEvent)].Add(new Subscription<TEvent>(action)); // E
        }

        public void Unsubscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
        {
            if (subscriptions.ContainsKey(typeof(TEvent)))
            {
                var subs = subscriptions[typeof(TEvent)];
                subs.RemoveAll(subscription => (subscription).Matches(action)); // E
            }
        }

        public void Publish<TEvent>(TEvent e) where TEvent : IEvent
        {
            if (subscriptions.ContainsKey(typeof(TEvent)))
            {
                foreach (Subscription<IEvent> subscription in subscriptions[typeof(TEvent)])
                {
                    UnityEngine.Debug.Log(subscription);
                    (subscription as Subscription<TEvent>).Publish(e);
                }
            }
        }
    }
}
