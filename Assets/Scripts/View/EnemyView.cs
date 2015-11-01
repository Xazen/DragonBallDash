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

    [Header("Life")]
    public int Life = 3;

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
    private int multiFire = 1;
    [SerializeField]
    private float multiFireRate = 0.33f;

    [SerializeField]
    private Animator _animator;

    [Header("DragonBall")]
    [SerializeField]
    private string _dragonBall;

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
        if (_animator != null)
        {
            _animator.SetTrigger(DIE);
        }

        if (_dragonBall != null && _dragonBall != "")
        {
            GameObject dbObj = GameObject.FindGameObjectWithTag(_dragonBall);

            if (dbObj == null)
            {
                Debug.LogError("DB object not found: " + _dragonBall, this);
                return;
            }

            Image dbImg = dbObj.GetComponent<Image>();

            if (dbImg != null)
            {
                Color activeColor = dbImg.color;
                activeColor.a = 1.0f;

                dbImg.color = activeColor;
            }
            else
            {
                Debug.LogError("DB Image not found: " + _dragonBall, this);
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);

            for (int i = 0; i < multiFire; i++)
            {
                if (_animator != null)
                {
                    _animator.SetTrigger(ATTACK);
                    Instantiate(projectile, this.transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(multiFireRate);
                }
            }
        }

    }
}
