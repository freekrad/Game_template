using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenLoader : MonoBehaviour
{
  public string nextSceneName;
  public GameObject progressBar;
  public Image progressBarImage; // Спрайт полоски загрузки, на спрайте должна стоять галочка(заполняемый)***
  public Text loadingText;
  public GameObject pressKeyHint;
  public GameObject loadingImage;
  AsyncOporetion asyncOperation;
  
  private void Start()
  {
    if(SceneManager.GetActiveScene().name == "Scene_loading")
      StartCoroutine("AsyncLoadPressKeyCOR", PlayerPrefs.GetString('current_scene'));
  }
}
