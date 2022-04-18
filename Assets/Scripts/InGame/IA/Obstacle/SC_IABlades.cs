using UnityEngine;
namespace C_Thorn.InGame.IA
{
    public class SC_IABlades : SC_BasicIA
    {
          #region Attributes
          [Header("Control to Rotate blades")]
          [SerializeField] float _velocityToRotate;
          [SerializeField] GameObject _blades;
          #endregion  
    
          #region UnityCalls
          // Start is called before the first frame update
          void Start() => StartCoroutine(CorrutineDie(38));
          void Update() => UpdateUp();
          #endregion    
    
          #region Custom private Methods
          void UpdateUp()
          {
              ToForward();
              ToRotateAnimation();
          }
          void ToRotateAnimation() => _blades.transform.RotateAround(this.transform.position, Vector3.up, _velocityToRotate * Time.deltaTime);
          #endregion
    }
}
