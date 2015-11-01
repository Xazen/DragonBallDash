using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class GokuView : View
{
    public const string ANIMATION_ATTACK = "Attack";
    public const string ANIMATION_HURT = "Hurt";
    public const string ANIMATION_DIE = "Die";

    #region Inspector
    [Header("Setup")]
    [SerializeField]
    private Animator _gokuAnimator;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Lifebar Lifebar;

    [Header("Parameter")]
    [SerializeField]
    private float _speed;

    [Header("Projectile")]
    [SerializeField]
    private GameObject _kiBlast;

    [SerializeField]
    private float _fireRate = 1.5f;
    #endregion

    private float _fireDelay = 0.0f;

    public void Init()
    {
        
    }

    public void Update()
    {
        if (_fireDelay >= 0)
        {
            _fireDelay -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (_fireDelay <= 0)
        {
            _fireDelay = _fireRate;
            _gokuAnimator.SetTrigger(ANIMATION_ATTACK);

            Invoke("CreateKiBlast", 0.5f);
        }
    }

    public void Hurt()
    {
        _gokuAnimator.SetTrigger(ANIMATION_HURT);
    }

    public void Die()
    {
        _gokuAnimator.SetTrigger(ANIMATION_DIE);
    }

    private void CreateKiBlast()
    {
        Vector3 spawnPosition = this.transform.position;
        spawnPosition.y += 0.5f;
        Instantiate(_kiBlast, spawnPosition, Quaternion.identity);
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
