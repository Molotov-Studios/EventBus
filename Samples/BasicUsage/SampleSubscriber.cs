using UnityEngine;
using SimpleEventBus;

public class SampleSubscriber : MonoBehaviour
{
    private void Start()
    {
        GlobalEventBus.Subscribe<SampleEvent>(OnSampleMessage);
    }

    private void OnSampleMessage(SampleEvent e)
    {
        Debug.Log($"Sample event received with message: {e.message}");
    }
}
