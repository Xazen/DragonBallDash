using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;

    [SerializeField]
    private Text _text;

    private float currentAlpha = 0;

    public void Update()
    {
        Color color = _text.color;
        color.a = Mathf.Round(Mathf.PingPong(Time.time * _speed, 1.0f));

        _text.color = color;
    }
}
