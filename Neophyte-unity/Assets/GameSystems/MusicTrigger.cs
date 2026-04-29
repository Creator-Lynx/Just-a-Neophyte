using UnityEngine;
using UnityEngine.Events;

public class MusicTrigger : MonoBehaviour
{
    bool isUsed = false;
    [SerializeField] int stage = 0;
    void OnTriggerEnter(Collider other)
    {
        //do text
        if(!isUsed)
        {
            MusicSetter.SetSnapshot(stage);
            isUsed = true;
        }

    }

}
