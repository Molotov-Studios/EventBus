using System;
using System.Collections.Generic;

namespace SimpleEventBus
{
    public class EventBus
    {
        public static readonly EventBus global = new EventBus();

        private readonly Dictionary<Type, dynamic> subscriptions;

        public EventBus()
        {
            subscriptions = new Dictionary<Type, dynamic>();
        }

        public void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
        {
            Subscriptions<TEvent>().Add(new Subscription<TEvent>(action));
        }

        public void Unsubscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
        {
            Subscriptions<TEvent>().RemoveAll(subscription => (subscription).Matches(action));
        }

        public void Publish<TEvent>(TEvent e) where TEvent : IEvent
        {
            foreach (Subscription<TEvent> subscription in Subscriptions<TEvent>())
            {
                (subscription as Subscription<TEvent>).Publish(e);
            }
        }

        private List<Subscription<TEvent>> Subscriptions<TEvent>() where TEvent : IEvent
        {
            if (!subscriptions.ContainsKey(typeof(TEvent)))
            {
                subscriptions.Add(typeof(TEvent), new List<Subscription<TEvent>>());
            }

            return subscriptions[typeof(TEvent)] as List<Subscription<TEvent>>;
        }
    }
}
