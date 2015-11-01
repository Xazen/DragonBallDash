using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using DG.Tweening;

public class BackgroundView : EventView
{
    [SerializeField]
    private float animationDuration = 3.0f;

    private float startX;

    protected override void Start()
    {
        startX = this.transform.localPosition.x;

        this.transform.DOLocalMoveX(-4.6f, animationDuration).OnComplete(Reset).SetLoops(-1).SetEase(Ease.Linear);
    }

    private void Reset()
    {
        Vector2 target = this.transform.localPosition;
        target.x = startX;

        this.transform.localPosition = target;
    }
}
