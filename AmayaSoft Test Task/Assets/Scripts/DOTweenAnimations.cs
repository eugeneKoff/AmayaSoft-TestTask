using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class DOTweenAnimations
{
    public static Tween Fade(this Image image, float value, float duration)
    {
        Tween tw = image.DOFade(value, duration);

        return tw;
    }
    
}
