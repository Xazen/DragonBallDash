using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

public class InputSignal : Signal<InputSignal.Key, InputSignal.State>
{
    public enum Key
    {
        None,
        Up,
        Down,
        Action
    }

    public enum State
    {
        Up,
        Down
    }
}
