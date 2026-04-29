using UnityEngine;
using TMPro;

public class InteractionHint : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Canvas canvas;
    public void ShowHint (string str)
    {
        text.text = str;
        canvas.enabled = true;
    }

    public void HideHint()
    {
        canvas.enabled = false;
    }
}
