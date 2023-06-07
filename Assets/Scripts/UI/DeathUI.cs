using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class DeathUI : MonoBehaviour
{
    [SerializeField] GameObject buton01;
    [SerializeField] float deathUIBlackoutSpeed;

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Activation()
    {
        StartCoroutine(BlackoutOn(GetComponent<Image>()));
    }

    IEnumerator BlackoutOn(Image bg)
    {
        Color col = bg.color;

        while (Time.timeScale > 0.01f)
        {
            float blackoutSpeed = deathUIBlackoutSpeed * Time.deltaTime;
            col.a += blackoutSpeed;
            bg.color = col;

            Time.timeScale -= blackoutSpeed;

            yield return null;
        }

        buton01.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        ThirdPersonController.LockCameraPosition = true;

        Time.timeScale = 0;
    }
}
