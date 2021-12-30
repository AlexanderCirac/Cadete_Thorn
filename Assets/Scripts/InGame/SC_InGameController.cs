using System.Collections;
using UnityEngine;
using C_Thorn.InGame.Player;


namespace C_Thorn.InGame
{
      public class SC_InGameController : MonoBehaviour
      {

          #region Attributes
          private bool _endCorrutineVictory = false;
          [SerializeField] private GameObject _player;

          //Main Tools
          [Header("Main Tools")]
          public SC_InGameManager _inGameManager;
          public static SC_InGameController instance;

          [Header("Control position Respawn")]
          public GameObject _posrespawnLeft;
          public GameObject _posrespawnRight;

          

          #endregion

          #region UnityCalls
          void Start()
          {     
                StartCoroutine(nameof(ConditionVictoryCorrutine));
                StartCoroutine(nameof(CorrutineRecalculatePosRespawn));
                SC_PlayerController.OnReloadPoints += IncresPoints;
                SC_PlayerController.OnIncresTime += IncresTime;
                instance = this;
          }
          private void OnDestroy()
          {
                SC_PlayerController.OnReloadPoints -= IncresPoints;
                SC_PlayerController.OnIncresTime -= IncresTime;
          }
          #endregion

          #region Methods    
          IEnumerator ConditionVictoryCorrutine() 
          {
              while(!_endCorrutineVictory)
              {
                  //win
                  if(_inGameManager._countPoints >= _inGameManager._countPointsMax)
                  {
                      _inGameManager._winGame = true;
                      Time.timeScale = 0;
                      _endCorrutineVictory = false;
                  }
                  //defeat
                  if(_player == null || _inGameManager._countTime <= 0 )
                  { 
                      _inGameManager._endGame = true;
                      Time.timeScale = 0;
                      _endCorrutineVictory = false;
                  }
                  yield return null;
              }
          }          
          IEnumerator CorrutineRecalculatePosRespawn() 
          {
                  //Recalculate position with type screen
                  Vector2 m_posCamaraP = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                  Vector2 m_posCamaraN = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, -Screen.height, Camera.main.transform.position.z));
                  
                  //recalculate position left
                  _posrespawnLeft.transform.position = new Vector3((m_posCamaraN.x +(m_posCamaraP.x +(m_posCamaraP.x/6) )), _posrespawnLeft.transform.position.y, _posrespawnLeft.transform.position.z);

                  // Recalculate position Right
                   _posrespawnRight.transform.position = new Vector3((m_posCamaraP.x -(m_posCamaraP.x/5)),_posrespawnRight.transform.position.y, _posrespawnRight.transform.position.z);
                  yield return null;
              
          }

          public void IncresPoints()
          {
              _inGameManager._countPoints += 10;
          }          
          private void IncresTime()
          {
              Time.timeScale = 9;
              Invoke(nameof(NormalizeTime),2f);  
          }          
          private void NormalizeTime()
          {
              Time.timeScale = 1;
          }

          
          #endregion
      }
}
