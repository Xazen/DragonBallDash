using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class RootView : View
{
    [Inject]
    public InputSignal InputSignal { get; set; }

    private KeyCode[] inputOptions =
    {
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.Space
    };

    public void Update()
    {

        // Dispatch Up
        foreach (KeyCode keyCode in inputOptions)
        {
            InputSignal.Key key = InputSignal.Key.None;

            switch (keyCode)
            {
                case KeyCode.UpArrow:
                    key = InputSignal.Key.Up;
                    break;
                case KeyCode.DownArrow:
                    key = InputSignal.Key.Down;
                    break;
                case KeyCode.Space:
                    key = InputSignal.Key.Action;
                    break;
            }

            if (Input.GetKeyDown(keyCode))
            {
                InputSignal.Dispatch(key, InputSignal.State.Down);
            }

            if (Input.GetKeyUp(keyCode))
            {
                InputSignal.Dispatch(key, InputSignal.State.Up);
            }
        }
    }
}
