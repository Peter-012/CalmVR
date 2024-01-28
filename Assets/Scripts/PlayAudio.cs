using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audio;
    void Start()
    {
        audio.Play();
    }
}