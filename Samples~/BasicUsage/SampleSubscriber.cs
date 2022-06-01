using UnityEngine;
using SimpleEventBus;

public class SampleSubscriber : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.global.Subscribe<SampleEvent>(OnSampleMessage);
    }

    private void OnDisable()
    {
        EventBus.global.Unsubscribe<SampleEvent>(OnSampleMessage);
    }

    private void OnSampleMessage(SampleEvent e)
    {
        Debug.Log($"Sample event received on {gameObject.name} with message: {e.message}");
    }
}
