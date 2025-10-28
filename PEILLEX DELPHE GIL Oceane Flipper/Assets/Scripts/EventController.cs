using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public UnityEvent onTriggerEnterEvent;
    public UnityEvent onTriggerExitEvent;
    public UnityEvent onCollisionEnterEvent;
    void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        onTriggerExitEvent.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        onCollisionEnterEvent.Invoke();
    }
    
}
