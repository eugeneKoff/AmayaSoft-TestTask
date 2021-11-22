using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;


public class Restart : MonoBehaviour
{
    [SerializeField]
    private Image _loadingScreen;

    [SerializeField]
    private Image _darkScreen;

    [SerializeField]
    private GameObject _button;

    [SerializeField]
    private float _fadeDuration;

    [SerializeField]
    private GameObject _restartCanvas;

    [SerializeField]
    private UnityEvent _OnRestart;

    private void OnEnable()
    {
        //FadeIn

    }

    private void SwitchLoadingScreen(bool On)
    {
        

        _loadingScreen.gameObject.SetActive(On);

    }

    public void RestartGame()
    {

        StartCoroutine(RestartLevel());
    }
    
    IEnumerator RestartLevel()
    {
        _loadingScreen.gameObject.SetActive(true);

        Tween fadingTween;
        fadingTween = _loadingScreen.Fade(1, _fadeDuration);
        yield return fadingTween.WaitForCompletion();

        _OnRestart?.Invoke();

        _button.SetActive(false);

        _darkScreen.gameObject.SetActive(false);

        fadingTween = _loadingScreen.Fade(0, _fadeDuration);

        yield return fadingTween.WaitForCompletion();

        _loadingScreen.gameObject.SetActive(false);
        SwitchRestartCanvas(false);
    }

    public void SwitchRestartCanvas(bool On)
    {
        if (On)
        {
            _darkScreen.Fade(0.8f, _fadeDuration);
        }
        else
        {
            _darkScreen.Fade(0, _fadeDuration);

        }

        _button.SetActive(On);

        _darkScreen.gameObject.SetActive(On);
        
        _restartCanvas.SetActive(On);
        
       
    }
    
}


