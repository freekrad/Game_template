using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class MainHero : MonoBehaviour
{
  [SerializeField] float deadlyFallHeight = 100;
  private float _startFallHeight;
  private bool _isFall = false;
  
  void Start() {
  ThirdPersonController.HitStartFall += StartFall;
  ThirdPersonController.HitEndFall += EndFall;
  }
  
  void StartFall() {
    if(_isFall)
      return;

      _isFall = true;
    _startFallHeight = transform.position.y;
  }
  
  void EndFall() {
    if(!_isFall)
      return;
    
    _isFall = false;

    Debug.Log(_startFallHeight - transform.position.y);
    
    if(_startFallHeight - transform.position.y >= deadlyFallHeight)
    Die();
  }
  
  void Die(){
    Debug.Log("Умер!");
  }
}
