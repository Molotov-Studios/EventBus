# Simple Event Bus

Yet another event bus C# implementation, for Unity. Heavily inspired on [GameEventBus](https://github.com/ThomasKomarnicki/GameEventBus), by [ThomasKomarnicki](https://github.com/ThomasKomarnicki).

## Installation

Go to the Unity Package Manager (`Window > Package Manager`), open the `+` dropdown on the top-left corner and select `Add package from git URL...`, and provide the following git URL:

```
git@github.com:Molotov-Studios/SimpleEventBus.git
```

## Usage

To use this library properly, you should:

1. Create your custom events by implementing the `SimpleEventBus.IEvent` interface
2. Either create a `SimpleEventBus.EventBus` instance or use `SimpleEventBus.EventBus.global`
3. Subscribe and unsubscribe to events using its `Subscribe/Unsubscribe` methods
4. Publish events by using the `Publish` method

For example, using the static `SimpleEventBus.EventBus.global` default bus:

```cs
// Create an event by implementing the SimpleEventBus.IEvent interface
public class HelloEvent : SimpleEventBus.IEvent
{
    // You can use any kind of parameters and/or methods
    public HelloEvent(int firstParameter, string secondParameter) { }
}

// Example of a publisher
public class HelloPublisher : MonoBehaviour
{
    private void Update()
    {
        // Check your condition
        SimpleEventBus.EventBus.global.Publish<HelloEvent>(new HelloEvent(42, "hi!"));
    }
}

// Example of a subscriber
public class HelloSubscriber : MonoBehaviour
{
    private void OnEnable()
    {
        SimpleEventBus.EventBus.global.Subscribe<HelloEvent>(OnHelloEvent);
    }

    private void OnDisable()
    {
        SimpleEventBus.EventBus.global.Unsubscribe<HelloEvent>(OnHelloEvent);
    }

    private void OnHelloEvent(HelloEvent e)
    {
        Debug.Log("Received HelloEvent!");
    }
}
```

With a local `SimpleEventBus.EventBus` instance:

```cs
// Create an event by implementing the SimpleEventBus.IEvent interface

// Example of a publisher
public class ClosedSystem
{
    private class HelloEvent : SimpleEventBus.IEvent
    {
        public HelloEvent() { }
    }

    private void CustomMethod()
    {
        SimpleEventBus.EventBus bus = new SimpleEventBus.EventBus();
        bus.Subscribe<HelloEvent>(OnHelloEvent);
        bus.Publish<HelloEvent>(new HelloEvent());
    }

    private void OnHelloEvent(HelloEvent e)
    {
        // Handle event
    }
}
```
