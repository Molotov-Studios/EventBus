using System;

namespace SimpleEventBus
{
    internal class Subscription<TEvent> : ISubscription<TEvent> where TEvent : IEvent
    {
        private readonly Action<TEvent> action;
        private bool publishing;

        public Subscription(Action<TEvent> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.action = action;
            this.publishing = false;
        }

        public void Publish(TEvent e)
        {
            if (!(e is TEvent))
            {
                throw new ArgumentException("Event is not the correct type.");
            }

            if (!this.publishing)
            {
                this.publishing = true;
                action.Invoke(e);
                this.publishing = false;
            }
        }

        public bool Matches(Action<TEvent> action)
        {
            return this.action == action;
        }
    }
}
