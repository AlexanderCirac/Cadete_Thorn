using UnityEngine;
using System.Collections;

namespace C_Thorn.InGame.IA
{
    public class SC_IAWall : SC_BasicIA 
    {

          #region Attributes
          [Header("Change Walls")]
          [SerializeField] private GameObject _wall1;
          [SerializeField] private GameObject _wall2;
          private  bool   _flipFlopWalls = false;

          //Animation Blink Walls
          [Header("Blink Walls")]
          [SerializeField] private float  _timeBlink = 0.5f;
          private  float  _savetimeBlink;
          private  bool   _blinkWalls = false;

          //corrutines
          private  bool   _corrutinEnding;


          #endregion
          private void Awake()
          {
              _savetimeBlink = _timeBlink;
          }
          #region UnityCalls
          void Start()
          {
              
              StartCoroutine(CorrutineDie(38));
              StartCoroutine(CorrutineFlipFlopWalls());
              StartCoroutine(CorrutineBlink());
          }

          private void Update()
          {
              ToForward();
          }
          private void OnDestroy()
          {
              _corrutinEnding = true;
          }
          #endregion

          #region Methods
          IEnumerator CorrutineFlipFlopWalls()
          {
             while(!_corrutinEnding)
             {
                  yield return new WaitForSeconds(_savetimeBlink);
                  ToFlipFlopWalls(_flipFlopWalls);
                  _flipFlopWalls = !_flipFlopWalls;

             }
             
          }   
          IEnumerator CorrutineBlink()
          {
             while(!_corrutinEnding)
             {
                  yield return new WaitForSeconds(_timeBlink);
                  ToDecreaseTime();
             }
          }          
         
          private void ToFlipFlopWalls(bool _flipFlop)
          {
              _timeBlink = _savetimeBlink;
              _wall1.SetActive(_flipFlop);
              _wall2.SetActive(!_flipFlop);
          }
          private void ToDecreaseTime()
          {
              _blinkWalls = !_blinkWalls;

              if(_timeBlink > (_savetimeBlink * 10) / 100)
              _timeBlink -= ((_timeBlink * 60)/100);

              ToBlinkWalls(_flipFlopWalls, _blinkWalls);

          }
          private void ToBlinkWalls(bool _flipFlop, bool _blink)
          {
                switch (_flipFlop)
                {
                    case false:
                       _wall1.SetActive(!_blink);
                       break;
                    case true:
                      _wall2.SetActive(_blink);
                      break;
                }
          } 
          #endregion
    }
}
