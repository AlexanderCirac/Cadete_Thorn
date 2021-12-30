using System.Collections;
using UnityEngine;
using C_Thorn.InGame;


namespace C_Thorn.InGame.IA
{
    public class SC_IARobot : SC_BasicIA
  {
          #region Attributes
          private bool _endCorrutineRotate;
          [Header("Control to Rotate blades")]
          [SerializeField]private float _velocityToRotate;
          [SerializeField]private GameObject _blades;
          [Header("Control to shoot")]
          [SerializeField] private GameObject _canon;
          [SerializeField] private GameObject _bulletEnemy;
          #endregion  
    
          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
              StartCoroutine(CorrutineToMove());
              StartCoroutine(CorrutineToDieInTime(38));
              StartCoroutine(CorrutineUpdate());
          }
          private void OnDestroy()
          {
                _endCorrutineRotate = true;
          }
          private void OnTriggerEnter(Collider _coll)
          {
              if(_coll.CompareTag("BulletPlayer"))
              {
                Destroy(this.gameObject);
              }
          }
          #endregion

          #region Methods
          IEnumerator CorrutineUpdate()
          {
              while(_endCorrutineRotate)
              {
                  AnimationRotate();
                  LoockAtPlayer();
                  yield return null;
              }
          }
          private void AnimationRotate()
          {   
              _blades.transform.RotateAround(this.transform.position, Vector3.up, _velocityToRotate * Time.deltaTime);
          }          
          
          private void LoockAtPlayer()
          {   
              if(!SC_InGameManager._instance._endGame && SC_InGameManager._instance._winGame)
              {
                  GameObject _player = GameObject.FindGameObjectWithTag("Player");
                  this.transform.LookAt(_player.transform);
                  DetectetToShootPlayer(_player);
              }
          }          
          private void DetectetToShootPlayer(GameObject _player)
          {   
              if( (_player.transform.position - this.transform.position).sqrMagnitude > 4*4)
              {
                  Invoke(nameof(ShootToPlayer),.5f);
              }
          }
          private void ShootToPlayer() 
          {
              Instantiate(_bulletEnemy, _canon.transform.position, _canon.transform.rotation);  
          }
          #endregion
    }

}
