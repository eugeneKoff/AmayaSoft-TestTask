using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextAnimation : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _taskText;

    [SerializeField]
    private float _duration;


    private void OnEnable()
    {
        FadeIn(_duration);
    }

    private void FadeIn(float duration)
    {

        _taskText.DOFade(1, duration).From(0);
    }

}
