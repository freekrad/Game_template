using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class BackgroundGameUI : MonoBehaviour
{
    [SerializeField] float blackoutSpeed = 2;

    public void SetBlackout(bool value)
    {
        if(value)
            StartCoroutine(BlackoutOn(GetComponent<RawImage>()));
        
    }

    IEnumerator BlackoutOn(RawImage bgImg)
    {
        Color col = bgImg.color;

        while (Time.timeScale > 0.01f)
        {
            float _blackoutSpeed = blackoutSpeed * Time.deltaTime;
            col.a += _blackoutSpeed;
            bgImg.color = col;

            Time.timeScale -= _blackoutSpeed;

            yield return null;
        }

        Time.timeScale = 0;
        col.a = 1f;
    }
}
