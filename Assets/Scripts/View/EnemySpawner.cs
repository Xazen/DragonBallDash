using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;

public class EnemySpawner : EventView
{
    [Inject]
    public SoundtrackSignal SoundtrackSignal { get; set; }

    [Header("Unique")]
    [SerializeField]
    private List<GameObject> _enemySpawnList;

    [SerializeField]
    private List<float> _enemySpawnTime;

    [SerializeField]
    private List<Vector2> _enemySpawnVector;

    [Header("Minions")]
    [SerializeField]
    private List<GameObject> _minionSpawnList;

    [SerializeField]
    private List<float> _spawnFrequency;

    [SerializeField]
    private List<Vector2> _StartEndTime;

    [SerializeField]
    private List<Vector2> _minionSpawnVector;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        SoundtrackSignal.AddListener(OnSoundtrackSignal);
    }

    private void OnSoundtrackSignal(float seconds)
    {
        // Spawn unique
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

        // Spawn minion
        for (int i = 0; i < _minionSpawnList.Count; i++)
        {
            float frequency = _spawnFrequency[i];
            Vector2 startEndTime = _StartEndTime[i];

            float startTime = startEndTime.x;
            float endTime = startEndTime.y;

            bool inTimeFrame = (seconds >= startTime && seconds <= endTime);
            bool correctTime = (seconds - startTime) % frequency == 0;

            if (inTimeFrame && correctTime)
            {
                GameObject enemy = _minionSpawnList[i];
                Vector2 positon = _minionSpawnVector[i];

                Instantiate(enemy, new Vector3(positon.x, positon.y, 0), Quaternion.identity);
            }
        }
    }
}
