using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ManagerGameUI : MonoBehaviour
{
    // добавить переключение чувствительности мыши, с игровой на менюшную                                       ***
    // добавить кулдаун, открытия/закрытия меню и перехода между основными менюшками.                           ***
    //  Во время смерти учитываться не должен

    [SerializeField] GameObject backgroundGameUI;
    [SerializeField] GameObject deathUI;

    private bool _isActive = false;

    private void Start()
    {
        MainHero.OnDie.AddListener(ActivDeathUI);
    }

    private void ActivDeathUI()
    {
        SetActive(true);
        deathUI.SetActive(true);
    }

    private void SetActive(bool newValue)
    {
        if (newValue == _isActive)
            return;
        _isActive = newValue;

        backgroundGameUI.SetActive(_isActive);
        backgroundGameUI.GetComponent<BackgroundGameUI>().SetBlackout(_isActive);
        ThirdPersonController.LockCameraPosition = _isActive;
        Cursor.visible = _isActive;

        if (_isActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
