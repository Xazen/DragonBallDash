using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class GokuView : View
{
    public const string ANIMATION_ATTACK = "Attack";
    public const string ANIMATION_HURT = "Hurt";
    public const string ANIMATION_DIE = "Die";
    public const string ANIMATION_WIN = "Win";

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

    [Header("Sounds")]
    [SerializeField]
    private AudioSource _audioSource;

    public AudioClip HurtClip;
    public AudioClip DieClip;
    public AudioClip WinClip;
    public AudioClip AttackClip;
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

        if (this.transform.position.y <= -5 && _rigidbody.velocity.y < 0)
        {
            ResetMove();
        }

        if (this.transform.position.y >= 3.5 && _rigidbody.velocity.y > 0)
        {
            ResetMove();
        }
    }

    public void Attack()
    {
        if (_fireDelay <= 0)
        {
            _fireDelay = _fireRate;
            _gokuAnimator.SetTrigger(ANIMATION_ATTACK);

            Invoke("CreateKiBlast", 0.25f);
        }
    }

    public void Hurt()
    {
        _audioSource.PlayOneShot(HurtClip);
        _gokuAnimator.SetTrigger(ANIMATION_HURT);
    }

    public void Die()
    {
        _audioSource.PlayOneShot(DieClip);
        _gokuAnimator.SetTrigger(ANIMATION_DIE);
    }

    public void Win()
    {
        _audioSource.PlayOneShot(WinClip); 
        _gokuAnimator.SetTrigger(ANIMATION_WIN);
    }

    private void CreateKiBlast()
    {
        _audioSource.PlayOneShot(AttackClip);

        Vector3 spawnPosition = this.transform.position;
        spawnPosition.y += 0.75f;
        Instantiate(_kiBlast, spawnPosition, Quaternion.identity);
    }

    public void MoveUp()
    {
        if (this.transform.position.y < 3.5)
        {
            _rigidbody.velocity = Vector2.up * _speed;
        }
    }

    public void MoveDown()
    {
        if (this.transform.position.y > -5)
        {
            _rigidbody.velocity = Vector2.down * _speed;
        }
    }

    public void ResetMove()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
