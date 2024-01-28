using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 NormalColor = Color.white;
    public Color32 HoverColor = Color.grey;
    public Color32 DownColor = Color.red;

    public new AudioSource audio;
    public AudioSource backgroundAudio;

    private Image Img = null;

    private void Awake()
    {
        Img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        Img.color = HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        Img.color = NormalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        Img.color = DownColor;

        audio.Play();
        IEnumerator fadeSound = AudioFadeOut.FadeOut(backgroundAudio, 0.5f);
        StartCoroutine(fadeSound);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }
}

public static class FadeAudioSource
{
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}