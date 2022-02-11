using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace C_Thorn.InGame 
{
    public class SC_RespawnObstacle : MonoBehaviour
    {
          #region Attributes
          private bool _endCorrutineRotate;
          [Header("Move Flip flop")]
          [SerializeField] private GameObject _objectLeft;
          [SerializeField] private GameObject _objectRight;
          public float _velocity = 5;
          private bool _isFlipFlop = false;
          [System.Serializable] public class ObjectToRespawnObstacles {
              public GameObject[] _arryObjects;
              [HideInInspector] public int _intRandom;
          }

          [Header("Object To Respawn")]
          [SerializeField] private ObjectToRespawnObstacles _variableRespawn;
          //Corrutines
          private bool _isEndCorrutine;
          #endregion  
    
          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
              StartCoroutine(CorrutineToInstantianteObstacle());
          }
          private void Update()
          {
              ToMoveFlipFlop(this.transform, _objectLeft.transform, _objectRight.transform, _velocity);
          }
          private void OnDestroy()
          {
              _isEndCorrutine = true;
          }
          #endregion    
    
          #region Methods
   
          IEnumerator CorrutineToInstantianteObstacle()
          {
              while (!_isEndCorrutine && !SC_InGameManager._instance._isLoset && !SC_InGameManager._instance._isWin)
              {
                  yield return new WaitForSeconds(2f);
                  _variableRespawn._intRandom = Random.Range(1, _variableRespawn._arryObjects.Length);
                  GameObject _objectToRespawn = _variableRespawn._arryObjects[_variableRespawn._intRandom -1];
                  Instantiate(_objectToRespawn, this.transform.position, _objectToRespawn.transform.rotation);
              }
          }
          public void ToMoveFlipFlop(Transform _originObject, Transform _posObject1, Transform _postObject2, float _velocity )
          {
              if (_isFlipFlop)
              {
                  if (_originObject.position.x > _posObject1.position.x )
                  {
                        _originObject.position = new Vector3(_originObject.position.x - _velocity * Time.deltaTime,
                        _originObject.position.y, 
                        _originObject.position.z);
                  }
                  else
                        _isFlipFlop = false;
              }
              else
              {
                  if (_originObject.position.x < _postObject2.position.x)
                  {
                        _originObject.position = new Vector3(_originObject.position.x + _velocity * Time.deltaTime,
                        _originObject.position.y, 
                        _originObject.position.z);
                  }
                  else
                        _isFlipFlop = true;
              }
          }
          #endregion
    }
}
