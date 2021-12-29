using System.Collections;
using UnityEngine;
namespace C_Thorn.InGame.IA
{
    public class SC_IABlades : SC_BasicIA
    {
          #region Attributes
          private bool _endCorrutineRotate;
          [Header("Control to Rotate blades")]
          [SerializeField]private float _velocityToRotate;
          [SerializeField]private GameObject _blades;
          #endregion  
    
          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
              StartCoroutine(CorrutineToMove());
              StartCoroutine(CorrutineToDieInTime(38));
              StartCoroutine(CorrutineRotate());
          }
          #endregion    
    
          #region Methods
          IEnumerator CorrutineRotate()
          {
              while(_endCorrutineRotate)
              {
                  _blades.transform.RotateAround(this.transform.position, Vector3.up, _velocityToRotate * Time.deltaTime);
                  yield return null;
              }
          }
          #endregion
    }
}
