﻿using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class KiBlastView : EventView
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private float _speed = 5.5f;

    protected override void Start()
    {
        base.Start();

        _rigidbody.velocity = Vector2.right * _speed;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == Tags.ENEMY)
        {
            Destroy(this.gameObject);
        }
    }
}