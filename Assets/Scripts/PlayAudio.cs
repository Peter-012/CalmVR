using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public new AudioSource audio;
    void Start()
    {
        audio.loop = true;
        audio.Play();
    }
}