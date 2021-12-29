using UnityEngine;

namespace C_Thorn.InGame.IA
{
    public class SC_IATrash : SC_BasicIA
    {
          #region UnityCalls
          void Start()
          {
              StartCoroutine(CorrutineToMove());
              StartCoroutine(CorrutineToDieInTime(8));
          }

          private void OnTriggerEnter(Collider _coll)
          {
              if(_coll.CompareTag("BulletPlayer"))
              {
                  SC_InGameController.instance.IncresPoints();
              }
              Destroy(this.gameObject);
          }
          #endregion
  }
}
