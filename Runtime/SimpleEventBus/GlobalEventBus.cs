using System;

namespace SimpleEventBus
{
    public static class GlobalEventBus
    {
        private static EventBus bus = new EventBus();

        public static void Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
        {
            bus.Subscribe<TEvent>(action);
        }

        public static void Unsubscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
        {
            bus.Unsubscribe<TEvent>(action);
        }

        public static void Publish<TEvent>(TEvent e) where TEvent : IEvent
        {
            bus.Publish<TEvent>(e);
        }
    }
}
