using UnityEngine;


namespace C_Thorn.InGame.IA
{
    public class SC_IARobot : SC_BasicIA
  {
          #region Attributes
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
              StartCoroutine(CorrutineDie(38));
          }
          private void Update()
          {
              ToForward();
              ToAnimationRotate();
              ToLoockAt();
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

                 

          private void ToAnimationRotate()
          {   
              _blades.transform.RotateAround(this.transform.position, Vector3.up, _velocityToRotate * Time.deltaTime);
          }          
          
          private void ToLoockAt()
          {   
              if(!SC_InGameManager._instance._isLoset && SC_InGameManager._instance._isWin)
              {
                  GameObject _player = GameObject.FindGameObjectWithTag("Player");
                  this.transform.LookAt(_player.transform);
                  ToDetectedPlayer(_player);
              }
          }          
          private void ToDetectedPlayer(GameObject _player)
          {   
              if( (_player.transform.position - this.transform.position).sqrMagnitude > 4*4)
              {
                  Invoke(nameof(ToShoot),.5f);
              }
          }
          private void ToShoot() 
          {
              Instantiate(_bulletEnemy, _canon.transform.position, _canon.transform.rotation);  
          }
          #endregion
    }

}
