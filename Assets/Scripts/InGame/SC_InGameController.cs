using UnityEngine;
using C_Thorn.InGame.Player;


namespace C_Thorn.InGame
{
      public class SC_InGameController : MyMonoBehaviour
      {

          #region Attributes
          [SerializeField] GameObject _player;

          [Header("Control position Respawn")]
          [SerializeField] GameObject _respawnLeft;
          [SerializeField] GameObject _respawnRight;
          #endregion

          #region UnityCalls
          void Start()
          {     
                ToRecalculatePos();
                SC_PlayerController.OnReloadPoints += ToIncresPoints;
                SC_PlayerController.OnIncresTime += ToIncresTime;
          }

          private void Update()
          {
              ToConditionVictory();
          }
          private void OnDestroy()
          {
                SC_PlayerController.OnReloadPoints -= ToIncresPoints;
                SC_PlayerController.OnIncresTime -= ToIncresTime;
          }
          #endregion

          #region Methods    
          private void ToConditionVictory() 
          {
                //win
                if(_inGameManager._totalPoints >= _inGameManager._pointsMax)
                {
                    _inGameManager._conditionVictoryEnum = ConditionVictoryEnum.win;
                    ToNormalizeTime(false);
                }
                //defeat
                if(_player == null || _inGameManager._time <= 0 )
                { 
                    _inGameManager._conditionVictoryEnum = ConditionVictoryEnum.lose;
                    ToNormalizeTime(false);
                }
          }          
          private void ToRecalculatePos() 
          {
                  //Recalculate position with type screen
                  Vector2 m_posCamaraP = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                  Vector2 m_posCamaraN = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, -Screen.height, Camera.main.transform.position.z));
                  
                  //recalculate position left
                  _respawnLeft.transform.position = new Vector3((m_posCamaraN.x +(m_posCamaraP.x +(m_posCamaraP.x/6) )), _respawnLeft.transform.position.y, _respawnLeft.transform.position.z);

                  // Recalculate position Right
                   _respawnRight.transform.position = new Vector3((m_posCamaraP.x -(m_posCamaraP.x/5)),_respawnRight.transform.position.y, _respawnRight.transform.position.z);
          }
          public void ToIncresPoints()
          {
              _inGameManager._totalPoints += 10;
          }          
          private void ToIncresTime()
          {
              Time.timeScale = 9;
              Invoke("ToNormalizeTime(true)",2f);  
          }          
          private void ToNormalizeTime(bool _value)
          {   
              Time.timeScale = _value ? 1: 0;
          }
          #endregion
      }
}
