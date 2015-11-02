using UnityEngine;
using System.Collections;

public class TitleScreenEvent : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
	    if (Input.anyKeyDown)
        {
            Application.LoadLevel(1);
        }
	}
}
