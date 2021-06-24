using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Waring : MonoBehaviour
{
    private float lerpTime = 0.1f;
    private TextMeshProUGUI textBossWarning;
    public Game_Manager instance;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }

    private IEnumerator ColorLerpLoop()
    {
        while(true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }
    private IEnumerator ColorLerp(Color StartColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent<1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            textBossWarning.color = Color.Lerp(StartColor, endColor, percent);

            yield return null;
        }
    }    
}
