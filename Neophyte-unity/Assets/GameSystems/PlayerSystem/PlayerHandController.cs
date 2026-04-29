using System.ComponentModel.Design;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    //[HelpKeyword("0 - empty\n1 - meat")]
    [SerializeField] GameObject[] items;
    static PlayerHandController instance;
    void Awake()
    {
        instance = this;
    }
    HandState currentState = HandState.empty;
    public static void SetState(HandState state)
    {
        instance.currentState = state;
        instance.SetVisualState(state);
    }

    public static HandState GetState()
    {
        return instance.currentState;
    }

    void SetVisualState(HandState state)
    {
        foreach(GameObject item in items)
        {
            item.SetActive(false);
        }
        int i = (int)state;
        if(i > 0 || i < items.Length) items[i].SetActive(true);
    }

    void Update()
    {
        //for some empty interactions with some item in hand
    }
}
public enum HandState
{
    empty,
    meat
}