using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class SoundtrackDispatcher : EventView
{
    [Inject]
    public SoundtrackSignal SoundtrackSignal { get; set; }

    private AudioSource _soundtrack;

    float currentTime = 0.0f;

    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
        _soundtrack = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (_soundtrack != null)
        {
            float timeNow = Mathf.Round(_soundtrack.time);
            if (currentTime != timeNow)
            {
                Debug.Log("Time: " + currentTime);

                currentTime = timeNow;
                SoundtrackSignal.Dispatch(currentTime);
            }
        }
    }
}
