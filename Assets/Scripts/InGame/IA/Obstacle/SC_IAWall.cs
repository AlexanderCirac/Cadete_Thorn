using UnityEngine;
using System.Collections;
using System;

namespace C_Thorn.InGame.IA
{
    public class SC_IAWall : SC_BasicIA 
    {

          #region Attributes
          [Header("Change Walls")]
          [SerializeField] private GameObject _wall1;
          [SerializeField] private GameObject _wall2;
          private bool _changeWalls = false;

          //Animation Blink Walls
          [Header("Blink Walls")]
          public float  _timeBlink = 0.5f;
          private float  _savetimeBlink;
          private bool _startToBlink = false;
          private bool _ToBlink = false;

          //corrutines
          private bool _endCorrutinechangeWalls;


          #endregion     
    
          #region UnityCalls
          void Start()
          {
              _savetimeBlink = _timeBlink;
              StartCoroutine(CorrutineToMove());
              StartCoroutine(CorrutineToDieInTime(38));
              StartCoroutine(CorrutineFlipFlop());
              StartCoroutine(StartCorrutineBlink());
          }

          private void Update()
          {
              if (_startToBlink)
              {
                  Invoke(nameof(ChangeBlink), _timeBlink);
                  AnimationBlinkWalls(_changeWalls, _ToBlink);
              }
          }
          private void OnDestroy()
          {
              _endCorrutinechangeWalls = true;
          }
          #endregion

          #region Methods
          IEnumerator CorrutineFlipFlop()
          {
             while(!_endCorrutinechangeWalls)
             {
                  yield return new WaitForSeconds(6);
                  ChangeWalls(_changeWalls);
                  _changeWalls = !_changeWalls;

             }
          }   
          IEnumerator StartCorrutineBlink()
          {
             while(!_endCorrutinechangeWalls)
             {
                  yield return new WaitForSeconds(5f);
                  _startToBlink = true;
             }
          }          
         
          void ChangeWalls(bool _flipFlop)
          {
             if(_flipFlop)
              { 
                  _wall1.SetActive(false);
                  _wall2.SetActive(true);
              
              }
             else
              {
                  _wall1.SetActive(true);
                  _wall2.SetActive(false);
              }

              _startToBlink = false;
              _timeBlink = _savetimeBlink;
          }
          void ChangeBlink()
          {
              _ToBlink = !_ToBlink;
              if(_timeBlink > (_savetimeBlink * 30) / 100)
              _timeBlink = _timeBlink - ((_savetimeBlink *80)/100);
          }
          void AnimationBlinkWalls(bool _flipFlop, bool _blink)
          {
             if(_flipFlop)
              { 
                  _wall1.SetActive(_blink);                 
              }
             else
              {
                  _wall2.SetActive(_blink);
              }
          } 
          #endregion
    }
}
