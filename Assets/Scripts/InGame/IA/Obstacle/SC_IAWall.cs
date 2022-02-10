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
          private  bool   _isFlipFlopWalls = false;

          //Animation Blink Walls
          [Header("Blink Walls")]
          [SerializeField] private float  _timeBlink = 0.5f;
          private  float  _saveTimeBlink;
          private  bool   _isBlinkWalls = false;

          //corrutines
          private  bool   _isCorrutinEnding;


          #endregion
          private void Awake()
          {
              _saveTimeBlink = _timeBlink;
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
              _isCorrutinEnding = true;
          }
          #endregion

          #region Methods
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
         
          private void ToFlipFlopWalls(bool _flipFlop)
          {
              _timeBlink = _saveTimeBlink;
              _wall1.SetActive(_flipFlop);
              _wall2.SetActive(!_flipFlop);
          }
          private void ToDecreaseTime()
          {
              _isBlinkWalls = !_isBlinkWalls;

              if(_timeBlink > (_saveTimeBlink * 10) / 100)
              _timeBlink -= ((_timeBlink * 60)/100);

              ToBlinkWalls(_isFlipFlopWalls, _isBlinkWalls);

          }
          private void ToBlinkWalls(bool _flipFlop, bool _blink)
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
