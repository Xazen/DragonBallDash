using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class EnemyBaseMediator : Mediator
{
    [Inject]
    public EnemyView View { get; set; }

    [Inject]
    public IEnemyModel EnemyModel { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        EnemyModel.MaxLive = View.Life;
        EnemyModel.Reset();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tags.KI_BLAST)
        {
            EnemyModel.DecreaseLive();

            if (EnemyModel.IsDead())
            {
                View.Die();
            }
            else
            {
                View.Hurt();
            }
        }
    }
}
