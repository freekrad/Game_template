using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ManagerGameUI : MonoBehaviour
{
    [SerializeField] GameObject deathUI;

    private void Start() {
        MainHero.OnDie.AddListener(ActivDeathUI);
    }

    private void ActivDeathUI(){
        deathUI.SetActive(true);
        deathUI.GetComponent<DeathUI>().Activation();
    }
    
}
