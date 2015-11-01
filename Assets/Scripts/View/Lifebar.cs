using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class Lifebar : View
{
    [SerializeField]
    private Image heartImage;

    private int _heartValue = 14;

	public void DecreaseHealth()
    {
        if (!IsEmpty())
        {
            Vector2 newSizeDelta = heartImage.rectTransform.sizeDelta;
            newSizeDelta.x -= _heartValue;

            heartImage.rectTransform.sizeDelta = newSizeDelta;
        }
    }

    public bool IsEmpty()
    {
        return (heartImage.rectTransform.sizeDelta.x == 0);
    }
}
