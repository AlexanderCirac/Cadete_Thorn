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
          private bool _changePosition = false;
          [System.Serializable] public class ObjectToRespawnObstacles {
              public GameObject[] _objectToRespwn;
              [HideInInspector] public int _intRandomRespawn;
          }

          [Header("Object To Respawn")]
          [SerializeField] private ObjectToRespawnObstacles _ObjectToRespawnObstacles;
          //Corrutines
          private bool _endCorrutine;
          #endregion  
    
          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
              StartCoroutine(CorrutineUpdate());
              StartCoroutine(CorrutineToInstantianteObstacle());
          }
          private void OnDestroy()
          {
              _endCorrutine = true;
          }
          #endregion    
    
          #region Methods
          IEnumerator CorrutineUpdate()
          {
              while (!_endCorrutine)
              {
                  ToMoveFlipFlop(this.transform, _objectLeft.transform, _objectRight.transform, _velocity);
                  yield return null;
              }
          }          
          IEnumerator CorrutineToInstantianteObstacle()
          {
              while (!_endCorrutine && !SC_InGameManager._instance._loseBool && !SC_InGameManager._instance._winBool)
              {
                  yield return new WaitForSeconds(2f);
                  _ObjectToRespawnObstacles._intRandomRespawn = Random.Range(1, _ObjectToRespawnObstacles._objectToRespwn.Length);
                  GameObject _objectToRespawn = _ObjectToRespawnObstacles._objectToRespwn[_ObjectToRespawnObstacles._intRandomRespawn -1];
                  Instantiate(_objectToRespawn, this.transform.position, _objectToRespawn.transform.rotation);
              }
          }
          public void ToMoveFlipFlop(Transform _originObject, Transform _posObject1, Transform _postObject2, float _velocity )
          {
              if (_changePosition)
              {
                  if (_originObject.position.x > _posObject1.position.x )
                  {
                        _originObject.position = new Vector3(_originObject.position.x - _velocity * Time.deltaTime,
                        _originObject.position.y, 
                        _originObject.position.z);
                  }
                  else
                        _changePosition = false;
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
                        _changePosition = true;
              }
          }
          #endregion
    }
}
