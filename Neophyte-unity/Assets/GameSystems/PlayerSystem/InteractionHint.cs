using UnityEngine;
using TMPro;

public class InteractionHint : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Canvas canvas;
    public void ShowHint (string str)
    {
        text.text = str;
        text.enabled = true;
    }

    public void HideHint()
    {
        text.enabled = false;
    }
}
