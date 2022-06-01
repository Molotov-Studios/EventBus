using UnityEngine;
using SimpleEventBus;

public class SamplePublisher : UnityEngine.MonoBehaviour
{
    private float timer = 0f;

    private void Update()
    {
        // Publish an event every 2 seconds
        if (timer >= 2f)
        {
            timer = 0f;
            GlobalEventBus.Publish<SampleEvent>(new SampleEvent("hi!"));
        }

        timer += Time.deltaTime;
    }
}
