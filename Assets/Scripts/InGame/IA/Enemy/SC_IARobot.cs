using UnityEngine;

namespace C_Thorn.InGame.IA
{
    public class SC_IARobot : SC_BasicIA
    {
          #region Attributes
          [Header("Control to Rotate blades")]
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
              ToRotate = 50f;
              ToLoockAt();
          }
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
           float ToRotate { set => _blades.transform.RotateAround(transform.position, Vector3.up, value * Time.deltaTime); }
          #endregion
    }

}
