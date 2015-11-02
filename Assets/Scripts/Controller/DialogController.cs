using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;

public class DialogController : View
{
    [SerializeField]
    private GameObject _loseDialog;

    [SerializeField]
    private GameObject _winDialog;

    [Inject]
    public LoseSignal LoseSignal { get; set; }

    [Inject]
    public WinSignal WinSignal { get; set; }

    protected override void Start()
    {
        base.Start();

        if (_loseDialog != null)
        {
            _loseDialog.SetActive(false);
        }

        if (_winDialog != null)
        {
            _winDialog.SetActive(false);
        }

        LoseSignal.AddListener(OpenLoseDialog);
        WinSignal.AddListener(OpenWinDialog);
    }

    private void OpenWinDialog()
    {
        if (_winDialog != null)
        {
            _winDialog.SetActive(true);
        }
    }

    private void OpenLoseDialog()
    {
        if (_loseDialog != null)
        {
            _loseDialog.SetActive(true);
        }
    }
}
