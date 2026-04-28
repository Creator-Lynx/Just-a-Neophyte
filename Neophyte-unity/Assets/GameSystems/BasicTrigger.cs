using UnityEngine;
using UnityEngine.Events;

public class BasicTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //do text
        triggerEvent.Invoke();
    }

    [SerializeField] UnityEvent triggerEvent;
}
