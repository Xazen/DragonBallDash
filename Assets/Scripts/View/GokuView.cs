using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class GokuView : View
{
    public const string ANIMATION_ATTACK = "Attack";

    #region Inspector
    [Header("Setup")]
    [SerializeField]
    private Animator _gokuAnimator;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [Header("Parameter")]
    [SerializeField]
    private float _speed;
    #endregion

    public void Init()
    {
        
    }

    public void Attack()
    {
        _gokuAnimator.SetTrigger(ANIMATION_ATTACK);
    }

    public void MoveUp()
    {
        _rigidbody.velocity = Vector2.up * _speed;
    }

    public void MoveDown()
    {
        _rigidbody.velocity = Vector2.down * _speed;
    }

    public void ResetMove()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
