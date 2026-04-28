using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class TextWriter : MonoBehaviour
{
    

    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] float timeToPrintSymbol = 0.05f;
    float defaultPitch;
    [SerializeField] float pitchRandomRange = 0.07f;
    [SerializeField] AudioClip printSound;
    [SerializeField] AudioSource printAudioSource;

    [SerializeField] Canvas canvas;

    public enum TextColor
    {
        yellow,
        white,
        red
    }
    public void Write(string text, TextColor color = TextColor.yellow)
    {
        StopAllCoroutines();
        isWriting = false;
        StartCoroutine(WriteText(text, color));
    }
    bool isWriting = false;
    bool wannaSkip = false;
    string[] colorPrefix = {"<color=yellow>", "<color=white>", "<color=red>"};
    string colorPostfix = "</color>";

    IEnumerator WriteText(string text, TextColor color)
    {
        isWriting = true;
        canvas.enabled = true;
        defaultPitch = printAudioSource.pitch;
        string stringBuffer = "";
        textMesh.text = string.Empty;
        for (int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSeconds(timeToPrintSymbol);
            printAudioSource.pitch = Random.Range(defaultPitch, defaultPitch + pitchRandomRange);
            printAudioSource.PlayOneShot(printSound);
            stringBuffer += text[i];
            textMesh.text = colorPrefix[(int)color] + stringBuffer + colorPostfix;
            
            if(wannaSkip)
            {
                textMesh.text = colorPrefix[(int)color] + text + colorPostfix;
                isWriting = false;
                break;
            }
        }
        isWriting = false;
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => interactInputAction.WasPressedThisFrame());
        canvas.enabled = false;
    }

    void Update()
    {
        if(isWriting)
            if(interactInputAction.WasPressedThisFrame()) wannaSkip = true;
    }

    InputAction interactInputAction;
    void Awake()
    {
        interactInputAction = InputSystem.actions.FindAction("Interact");
    }
}
