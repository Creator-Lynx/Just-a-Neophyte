using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class MusicSetter : MonoBehaviour
{
    [SerializeField]AudioMixer musicMixer;
    [SerializeField] AudioMixerSnapshot[] snapshots;
    public static void SetSnapshot(int id)
    {
        instance.operateSnapshot(id);
    }
    static MusicSetter instance;
    void Awake()
    {
        instance = this;
    }
    void operateSnapshot(int id)
    {
        if(id < 0 || id >= snapshots.Length) return;

        snapshots[id].TransitionTo(1f);
    }

    //test
    //void Update()
    //{
    //    if(Keyboard.current.digit1Key.wasPressedThisFrame) MusicSetter.SetSnapshot(1);
    //    if(Keyboard.current.digit2Key.wasPressedThisFrame) MusicSetter.SetSnapshot(2);
    //    if(Keyboard.current.digit3Key.wasPressedThisFrame) MusicSetter.SetSnapshot(3);
    //    if(Keyboard.current.digit4Key.wasPressedThisFrame) MusicSetter.SetSnapshot(4);
    //    if(Keyboard.current.digit5Key.wasPressedThisFrame) MusicSetter.SetSnapshot(5);
    //    if(Keyboard.current.digit6Key.wasPressedThisFrame) MusicSetter.SetSnapshot(6);
    //    if(Keyboard.current.digit7Key.wasPressedThisFrame) MusicSetter.SetSnapshot(7);
    //    if(Keyboard.current.digit8Key.wasPressedThisFrame) MusicSetter.SetSnapshot(8);
    //    if(Keyboard.current.digit9Key.wasPressedThisFrame) MusicSetter.SetSnapshot(9);
    //    if(Keyboard.current.digit0Key.wasPressedThisFrame) MusicSetter.SetSnapshot(10);
    //}
}
