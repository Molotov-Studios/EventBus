public class SampleEvent : SimpleEventBus.IEvent
{
    public string message { get; private set; }

    public SampleEvent(string message)
    {
        this.message = message;
    }
}
