using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class DragonBallDashRoot : ContextView
{
    void Awake()
    {
        context = new DragonBallDashContext(this);
    }
}
