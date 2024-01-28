using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 NormalColor = Color.white;
    public Color32 HoverColor = Color.grey;
    public Color32 DownColor = Color.red;

    public AudioSource audio;

    private Image Img = null;

    private void Awake()
    {
        Img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        Img.color = HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
     
        Img.color = NormalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        Img.color = DownColor;
<<<<<<< Updated upstream
        audio.Play();
=======
        
       // audio.Play();
       // IEnumerator fadeSound = AudioFadeOut.FadeOut(backgroundAudio, 0.5f);
       // StartCoroutine(fadeSound);
       // StopCoroutine(fadeSound);

       IEnumerator backgroundFade = FadeInOut.FadeTransition();
        StartCoroutine(backgroundFade);
       






        //  StartCoroutine(backgroundFade);
        //background fade out
>>>>>>> Stashed changes
    }

    public void OnPointerUp(PointerEventData eventData)
    {
  
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
