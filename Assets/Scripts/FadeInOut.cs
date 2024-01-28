using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    
    private static bool fadeIn, fadeOut = false;
    
    private float fadeTime = 0.01f;  //change this
    private Renderer rend;
    
    private static int currentScene = 0;
    private static string[] scenes = {"Env1", "Env2", "Env3"};
    public static GameObject currentObj;
    private int timePassed = 0;

    
    public static void nextScene()
    {
        
        int nextScene = currentScene++;
        if (nextScene >= scenes.Length)
        {
            nextScene = 0;
        }

        currentScene = nextScene;
        SceneManager.LoadScene(scenes[currentScene]);
    }
    
    
    
    
    public static void startFadeInTransition()
    {
        
        fadeIn = true;
        fadeOut = false;
    }

    
    
    private void fadeInTransition()
    {
        
        Material mat = currentObj.GetComponent<Renderer>().material;
        float curAlpha = mat.color.a;
        float nextAlpha = (float)Math.Max(curAlpha + 0.001, 1);
        
        changeAlpha(mat, nextAlpha);
        if (nextAlpha >= 1)
        {
            fadeIn = false;
        }
        
    }
    


    public static void startFadeOutTransition()
    {
        fadeOut = true;
        fadeIn = false;
    }
    
    
    private void fadeOutTransition()
    {

        
        Material mat = currentObj.GetComponent<Renderer>().material;
        float curAlpha = mat.color.a;
        float nextAlpha = (float)Math.Max(curAlpha - 0.01, 0);
        
        changeAlpha(mat, nextAlpha);
        if (nextAlpha <= 0)
        {
            fadeOut = false;
        }
    }



    private static void changeAlpha(Material mat, float newAlpha)
    {
        Color color = mat.color;
        Color nextColor = new Color(color.r, color.g, color.b, newAlpha);
        mat.SetColor("_Color", nextColor);
        
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentObj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
         fadeInTransition();
        else if (fadeOut)
            fadeOutTransition();
    }
}
