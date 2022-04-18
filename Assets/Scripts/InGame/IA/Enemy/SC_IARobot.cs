using UnityEngine;

namespace C_Thorn.InGame.IA
{
    public class SC_IARobot : SC_BasicIA
    {
          #region Attributes
          [Header("Control to Rotate blades")]
          [SerializeField] float _velocityToRotate;
          [SerializeField] GameObject _blades;
          [Header("Control to shoot")]
          [SerializeField] GameObject _canon;
          [SerializeField] GameObject _bulletEnemy;
          #endregion  
    
          #region UnityCalls
          // Start is called before the first frame update
          void Start() => StartCoroutine(CorrutineDie(38));
          void Update() => UpadteUP();

          void OnTriggerEnter(Collider _coll)
          {
              if(_coll.CompareTag("BulletPlayer"))
              {
                Destroy(this.gameObject);
              }
          }
          #endregion

          #region Custom private Methods
          void UpadteUP()
          {
              ToForward();
              ToAnimationRotate();
              ToLoockAt();
          }
          void ToAnimationRotate() => _blades?.transform.RotateAround(this.transform.position, Vector3.up, _velocityToRotate * Time.deltaTime);         
          
          void ToLoockAt()
          {   
              if(_inGameManager._conditionVictoryEnum == ConditionVictoryEnum.win)
              {
                  GameObject _player = GameObject.FindGameObjectWithTag("Player");
                  this.transform.LookAt(_player.transform);
                  ToDetectedPlayer(_player);
              }
          }          
          void ToDetectedPlayer(GameObject _player)
          {   
              if( (_player.transform.position - this.transform.position).sqrMagnitude > 4*4)
                  Invoke(nameof(ToShoot),.5f);
          }
          void ToShoot() => Instantiate(_bulletEnemy, _canon.transform.position, _canon.transform.rotation);  
          #endregion
    }

}
