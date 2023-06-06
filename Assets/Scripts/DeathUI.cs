using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
  [SerializeField] GameObject buton01;
  [SerializeField] float deathUIBlackoutSpeed;
  
  public void SwitchScene(string sceneName) {
    SceneManager.LoadScene(sceneName);
  }
  
  public void Activation()
  {
    StartCoroutine(BlackoutOn(GetComponent<RawImage>()));
  }
  
  IEnumerator BlackoutOn(RawImage bg)
  {
      Color col = bg.color;

      while (Time.timeScale > 0.01f)
      {
          float blackoutSpeed = deathUIBlackoutSpeed * Time.deltaTime;
          col.a += blackoutSpeed / 2;
          bg.color = col;

          Time.timeScale -= blackoutSpeed;

          yield return null;
      }

      buton01.SetActive(true);

      Cursor.visible = true;

      Time.timeScale = 0;
    }
}
