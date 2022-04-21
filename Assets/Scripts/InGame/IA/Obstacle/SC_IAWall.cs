using UnityEngine;
using System.Collections;

namespace C_Thorn.InGame.IA
{
    public class SC_IAWall : SC_BasicIA 
    {

          #region Attributes
          [Header("Change Walls")]
          [SerializeField] GameObject _wall1;
          [SerializeField] GameObject _wall2;
           bool   _isFlipFlopWalls = false;
          //Animation Blink Walls
          [Header("Blink Walls")]
          [SerializeField] float  _timeBlink = 0.5f;
          float _saveTimeBlink;
          bool   _isBlinkWalls = false;
          //corrutines
          bool   _isCorrutinEnding;
          #endregion

          #region UnityCalls
           void Awake() => Init();
          void Start() => StartUp();
          void Update() => ToForward();
          void OnDestroy() => _isCorrutinEnding = true;
          #endregion

          #region custom private Methods
          void Init() => _saveTimeBlink = _timeBlink;
          void StartUp()
          {
              StartCoroutine(CorrutineDie(38));
              StartCoroutine(CorrutineFlipFlopWalls());
              StartCoroutine(CorrutineBlink());
          }
          IEnumerator CorrutineFlipFlopWalls()
          {
             while(!_isCorrutinEnding)
             {
                  yield return new WaitForSeconds(_saveTimeBlink);
                  ToFlipFlopWalls(_isFlipFlopWalls);
                  _isFlipFlopWalls = !_isFlipFlopWalls;
             }
          }   
          IEnumerator CorrutineBlink()
          {
             while(!_isCorrutinEnding)
             {
                  yield return new WaitForSeconds(_timeBlink);
                  ToDecreaseTime();
             }
          }          
         
          void ToFlipFlopWalls(bool _flipFlop)
          {
              _timeBlink = _saveTimeBlink;
              _wall1.SetActive(_flipFlop);
              _wall2.SetActive(!_flipFlop);
          }
          void ToDecreaseTime()
          {
              _isBlinkWalls = !_isBlinkWalls;

              if(_timeBlink > (_saveTimeBlink * 10) / 100)
              _timeBlink -= ((_timeBlink * 60)/100);

              ToBlinkWalls(_isFlipFlopWalls, _isBlinkWalls);
          }
          void ToBlinkWalls(bool _flipFlop, bool _blink)
          {
                switch (_flipFlop)
                {
                    case false:
                       _wall1.SetActive(!_blink);
                       return;
                    case true:
                      _wall2.SetActive(_blink);
                      return;
                }
          } 
          #endregion
    }
}
