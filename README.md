# Simple Event Bus

Yet another event bus C# implementation, for Unity. Heavily inspired on [GameEventBus](https://github.com/ThomasKomarnicki/GameEventBus), by [ThomasKomarnicki](https://github.com/ThomasKomarnicki).

## Installation

Go to the Unity Package Manager (`Window > Package Manager`), open the `+` dropdown on the top-left corner and select `Add package from git URL...`, and provide the following git URL:

```
git@github.com:Molotov-Studios/SimpleEventBus.git
```

![2022-06-01 17-22-57](https://user-images.githubusercontent.com/2975360/171453248-a6163253-dde1-4938-916d-077c110d377b.gif)


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
using SimpleEventBus;

// Example of a publisher
public class ClosedSystem
{
    private class HelloEvent : IEvent
    {
        public HelloEvent() { }
    }

    private void CustomMethod()
    {
        EventBus bus = new EventBus();
        bus.Subscribe<HelloEvent>(OnHelloEvent);
        bus.Publish<HelloEvent>(new HelloEvent());
    }

    private void OnHelloEvent(HelloEvent e)
    {
        // Handle event
    }
}
```
