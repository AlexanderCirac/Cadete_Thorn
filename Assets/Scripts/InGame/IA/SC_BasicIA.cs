using UnityEngine;
using System.Collections;

namespace C_Thorn.InGame.IA
{
    public  class SC_BasicIA : MonoBehaviour
    {

          #region UnityCalls
          void Start()
          {
              StartCoroutine(CorrutineDie(8));
          }
          private void Update()
          {
              ToForward();
          }
          #endregion

          #region Methods
          protected IEnumerator CorrutineDie(int _time)
          {
              yield return new WaitForSeconds(_time);
              Destroy(this.gameObject);

          }
         public void ToForward()
          {
              this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,           this.gameObject.transform.position.z - (SC_InGameManager._velocityToMove + 0.5f) * Time.deltaTime);
          }
          #endregion

    }

}
