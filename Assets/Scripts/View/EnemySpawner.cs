using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;

public class EnemySpawner : EventView
{
    [Inject]
    public SoundtrackSignal SoundtrackSignal { get; set; }

    [SerializeField]
    private List<GameObject> _enemySpawnList;

    [SerializeField]
    private List<float> _enemySpawnTime;

    [SerializeField]
    private List<Vector2> _enemySpawnVector;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        SoundtrackSignal.AddListener(OnSoundtrackSignal);
    }

    private void OnSoundtrackSignal(float seconds)
    {
        for (int i = 0; i < _enemySpawnList.Count; i++)
        {
            float time = _enemySpawnTime[i];

            if (time == seconds)
            {
                GameObject enemy = _enemySpawnList[i];
                Vector2 positon = _enemySpawnVector[i];

                Instantiate(enemy, new Vector3(positon.x, positon.y, 0), Quaternion.identity);
            }
        }
    }
}
