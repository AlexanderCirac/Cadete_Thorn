using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace C_Thorn.InGame 
{
    public class SC_RespawnObstacle : MyMonoBehaviour
    {
          #region Attributes
          float _initialPosX;
          float _distanceScreen ;
          [Header("To Flip Flop velocity")]
          public  float _velocity = 5;
          [Header("Object Respawn")]
          public GameObject[] _arryObjects;
          #endregion  
    
          #region UnityCalls
          // Start is called before the first frame update
          void Awake() => Init();
          void Start() => StartCoroutine(CorrutineToInstantianteObstacle());

          private void Update() => ToMoveFlipFlop(this.transform, _distanceScreen, _velocity);
          #endregion    
   
          #region Custom private Methods
          IEnumerator CorrutineToInstantianteObstacle()
          {
              while (SceneManager.GetActiveScene().isLoaded && _inGameManager._conditionVictoryEnum == ConditionVictoryEnum.none)
              {
                  yield return new WaitForSeconds(2f);
                  GameObject _objectToRespawn = _arryObjects[GetIntRandom];
                  Instantiate(_objectToRespawn, this.transform.position, _objectToRespawn.transform.rotation);
              }
          }
          void ToMoveFlipFlop(Transform _originObject,float _distanceScreen, float _velocity )
          {
                _originObject.position = new Vector3(_initialPosX - (Mathf.PingPong(Time.time * _velocity, _distanceScreen) - 0.5f * _distanceScreen), _originObject.position.y, _originObject.position.z); ;
          }
          int GetIntRandom
          {
              get => Random.Range(1, _arryObjects.Length);
          }          
          void Init()
          {   
               Vector2 _anchorLeft = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
               Vector2 _anchorRight = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, -Screen.height, Camera.main.transform.position.z));
              _distanceScreen = (_anchorRight.x + (_anchorLeft.x + (_anchorLeft.x / 6))) - (_anchorLeft.x - (_anchorLeft.x / 5));

              _initialPosX = this.transform.position.x;
          }
          #endregion
    }
}
