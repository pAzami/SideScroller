using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    [SerializeField] AudioClip buttonClickSFX;

    public void playButtonClickSFX()
    {
        AudioSource.PlayClipAtPoint(buttonClickSFX, Camera.main.transform.position);
    }
}
