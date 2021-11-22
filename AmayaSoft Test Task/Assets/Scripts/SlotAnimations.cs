using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlotAnimations : MonoBehaviour
{
    [SerializeField]
    private float _duration;

    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private RectTransform _slotTranform;

    public void EaseInItemAnimation()
    {
        _itemImage.rectTransform.DOShakeScale(_duration, strength: 0.5f, vibrato: 5);
    }

    public void BounceYItemAnimation()
    {
        _itemImage.rectTransform.DOPunchPosition(new Vector2(0, 10f), _duration, vibrato: 3);
    }

    public void BounceXYSlotAnimation()
    {
        _slotTranform.DOScale(0, _duration).From(1);
        _slotTranform.DOShakeScale(_duration, strength: 0.5f, vibrato: 3);
    }
}
