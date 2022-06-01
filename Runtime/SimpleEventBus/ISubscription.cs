using System;

namespace SimpleEventBus
{
    internal interface ISubscription<TEvent> where TEvent : IEvent
    {
        public void Publish(TEvent e);
        public bool Matches(Action<TEvent> action);
    }
}
