using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TweenManagerUI : MonoBehaviour
{
    public float revealDuration = 1f;
    public RectTransform[] upYTransforms;
    public RectTransform[] downYTransforms;


    void Start()
    {
        //background.DOScale(Vector3.zero, 1f).From();

        foreach (RectTransform upYTransform in upYTransforms)
        {
            upYTransform.DOAnchorPosY(700f, revealDuration).From();

        }

        foreach (RectTransform downYTransform in downYTransforms)
        {
            downYTransform.DOAnchorPosY(-700f, revealDuration).From();
        }
    }

    public void OnClickTween(RectTransform rectTransform)
    {
        rectTransform.DOScale(rectTransform.localScale * 1.25f, revealDuration / 6f).SetLoops(2, LoopType.Yoyo);
    }
}