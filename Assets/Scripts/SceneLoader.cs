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
  AsyncOperation asyncOperation;
  
  private void Start()
  {
    if(SceneManager.GetActiveScene().name == "Scene_loading")
      StartCoroutine("AsyncLoadPressKeyCOR", PlayerPrefs.GetString("current_scene"));
  }
  
  public void SimpleLoadButton()
  {
    loadingImage.SetActive(true);
    SceneManager.LoadScene(nextSceneName);
  }
  
  public void AsyncLoadButton()
  {
    StartCoroutine("AsyncLoadCOR");
  }
  
  public void AsyncLoadPressKeyButton()
  {
    StartCoroutine("AsyncLoadPressKeyCOR", nextSceneName);
  }
  
  public void IntermediateSceneLoadButton()
  {
    PlayerPrefs.SetString("current_scene", nextSceneName);
    SceneManager.LoadScene("Scene_loading");
  }
  
  IEnumerator AsyncLoadCOR()
  {
    float loadingProgress;
    asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
    progressBar.SetActive(true);
    
    while(!asyncOperation.isDone)
    {
      loadingProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
      loadingText.text = $"Загрузка...{(loadingProgress*100)}%";
      progressBarImage.fillAmount = loadingProgress;
      yield return null;
    }
  }
  
  IEnumerator AsyncLoadPressKeyCOR(string sceneName)
  {
    float loadingProgress;
    asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
    progressBar.SetActive(true);
    
    asyncOperation.allowSceneActivation = false;
    while(asyncOperation.progress < 0.9f)
    {
      loadingProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
      loadingText.text = "Загрузка...{(loadingProgress*100)}%";
      progressBarImage.fillAmount = loadingProgress;
      yield return null;
    }
    
    progressBar.SetActive(false);
    pressKeyHint.SetActive(true);
  }
  
  private void Update()
  {
    if(pressKeyHint.activeSelf)
    {
      if(Input.anyKeyDown)
        asyncOperation.allowSceneActivation = true;
    }
  }
}
