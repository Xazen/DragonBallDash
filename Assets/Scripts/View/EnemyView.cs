using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class EnemyView : View
{
    private const string HURT = "Hurt";
    private const string DIE = "Die";
    private const string ATTACK = "Attack";

    [Header("Movement")]
    [SerializeField]
    private AnimationCurve movementCurveX;

    [SerializeField]
    private AnimationCurve movementCurveY;

    [SerializeField]
    private float animationDurationY = 5.0f;
    [SerializeField]
    private float animationDurationX = 5.0f;

    [Header("Projectile")]
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireRate = 0f;

    [SerializeField]
    private Animator _animator;

    [Header("DragonBall")]
    [SerializeField]
    private Image _dragonBall;

    protected override void Start()
    {
        base.Start();

        this.transform.DOMoveX(-5.0f, animationDurationX).SetEase(movementCurveX).SetLoops(-1);
        this.transform.DOMoveY(4.0f, animationDurationY).SetEase(movementCurveY).SetLoops(-1);

        if (fireRate > 0 && projectile != null)
        {
            StartCoroutine("Attack");
        }
    }

    public void Hurt()
    {
        _animator.SetTrigger(HURT);
    }

    public void Die()
    {
        _animator.SetTrigger(DIE);

        if (_dragonBall != null)
        {
            Color activeColor = _dragonBall.color;
            activeColor.a = 1.0f;

            _dragonBall.color = activeColor;
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);

            _animator.SetTrigger(ATTACK);

            Instantiate(projectile, this.transform.position, Quaternion.identity);
        }

    }
}
