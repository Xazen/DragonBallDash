using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using DG.Tweening;

public class EnemyView : View
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AnimationCurve movementCurveX;
    [SerializeField]
    private AnimationCurve movementCurveY;

    [SerializeField]
    private float animationDurationY = 5.0f;
    [SerializeField]
    private float animationDurationX = 5.0f;


    protected override void Start()
    {
        base.Start();

        this.transform.DOMoveX(-5.0f, animationDurationX).SetEase(movementCurveX).SetLoops(-1);
        this.transform.DOMoveY(4.0f, animationDurationY).SetEase(movementCurveY).SetLoops(-1);
    }
}
