using UnityEngine;

namespace C_Thorn.InGame.IA
{
    public class SC_IATrash : SC_BasicIA
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

          private void OnTriggerEnter(Collider _coll)
          {
              if(_coll.CompareTag("BulletPlayer"))
              {
                  SC_InGameController.instance.ToIncresPoints();
                  Destroy(this.gameObject);
              }
          }
          #endregion
  }
}
