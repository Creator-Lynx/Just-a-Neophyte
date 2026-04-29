using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PoclonInteractive : MonoBehaviour, IInteractivable
{
    [SerializeField] UnityEvent onCut;
    [SerializeField] UnityEvent onRelease;
    [SerializeField] UnityEvent getView;
    public string GetInteractionHint()
    {
        return "поклониться";
    }

    public void Interact()
    {
        StartCoroutine(Poklon());

    }

    IEnumerator Poklon()
    {
        GetComponent<Collider>().enabled = false;
        onCut.Invoke();
        yield return new WaitForSeconds(3);

        onRelease.Invoke();
        MusicSetter.SetSnapshot(3);
        yield return new WaitForSeconds(3);
        getView.Invoke();
    }

}
