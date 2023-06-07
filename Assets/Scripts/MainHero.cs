using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StarterAssets;
public class MainHero : MonoBehaviour
{
  public static UnityEvent OnDie = new UnityEvent();
    [SerializeField] float deadlyFallHeight = 100;
    private float _startFallHeight;
    private bool _isFall = false;

    void Start()
    {
        ThirdPersonController.OnStartFall.AddListener(StartFall);
        ThirdPersonController.OnEndFall.AddListener(EndFall);
    }

    void StartFall()
    {
        if (_isFall)
            return;

        _isFall = true;
        _startFallHeight = transform.position.y;
    }

    void EndFall()
    {
        if (!_isFall)
            return;

        _isFall = false;

        if (_startFallHeight - transform.position.y >= deadlyFallHeight)
            Die();
    }

    void Die()
    {
        OnDie?.Invoke();
    }
}
