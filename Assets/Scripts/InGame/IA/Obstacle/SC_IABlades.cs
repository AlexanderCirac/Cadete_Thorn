using UnityEngine;
namespace C_Thorn.InGame.IA
{
    public class SC_IABlades : SC_BasicIA
    {
          #region Attributes
          [Header("Control to Rotate blades")]
          [SerializeField] private float _velocityToRotate;
          [SerializeField] private GameObject _blades;
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
              ToRotateAnimation();
          }
          #endregion    
    
          #region Methods
          private void ToRotateAnimation()
          {
          
                  _blades.transform.RotateAround(this.transform.position, Vector3.up, _velocityToRotate * Time.deltaTime);
          }
          #endregion
    }
}
