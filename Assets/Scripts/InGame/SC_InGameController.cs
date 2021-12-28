using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace C_Thorn.InGame
{
      public class SC_InGameController : MonoBehaviour
      {

          #region Attributes
          private bool _endCorrutineVictory = false;
          //Main Tools
          [Header("Main Tools")]
          public SC_InGameManager _inGameManager;
          #endregion

          #region UnityCalls
          void Start()
          {
                StartCoroutine(nameof(ConditionVictoryCorrutine));
          }

          // Update is called once per frame
          void Update()
          {
            
          }
          #endregion

          #region Methods    
          IEnumerable ConditionVictoryCorrutine() 
          {
              while(!_endCorrutineVictory)
              {
                  //win
                  if(_inGameManager._countPoints >= _inGameManager._countPointsMax)
                  {
                      _inGameManager._winGame = true;
                      _endCorrutineVictory = true;
                  }
                  //defeat
                  if(_inGameManager._countTime <= 1)
                  {
                      _inGameManager._endGame = true;
                      _endCorrutineVictory = true;
                  }
                  yield return null;
              }
          }
          #endregion
      }
}
