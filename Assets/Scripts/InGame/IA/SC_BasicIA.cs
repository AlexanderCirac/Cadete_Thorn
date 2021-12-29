using UnityEngine;
using System.Collections;

namespace C_Thorn.InGame.IA
{
    public  class SC_BasicIA : MonoBehaviour
    {
          #region Attributes
          private bool _endCorrutineToMove;
          #endregion

          #region UnityCalls
          // Start is called before the first frame update
          void Start()
          {
                StartCoroutine(CorrutineToMove());
                StartCoroutine(CorrutineToDieInTime(8));
          }

          // Update is called once per frame
          void OnDestroy()
          {
              _endCorrutineToMove = true;
          }
          #endregion

          #region Methods
          protected IEnumerator CorrutineToMove()
          {
              while (!_endCorrutineToMove)
              {
                  MoveToForward();
                  yield return null;
              }
          }          
          protected IEnumerator CorrutineToDieInTime(int _time)
          {
                  yield return new WaitForSeconds(_time);
                  Destroy(this.gameObject);

          }
         public void MoveToForward()
          {
              this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - (SC_InGameManager._velocityToMove + 0.5f) * Time.deltaTime);
          }
          #endregion

    }

}
