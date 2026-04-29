using UnityEngine;
using UnityEngine.Events;

public class QuitTrigger : MonoBehaviour
{
    bool isUsed = false;
    void OnTriggerEnter(Collider other)
    {
        //do text
        if(!isUsed)
        {

            isUsed = true;
            Application.Quit();
        }

    }


}
