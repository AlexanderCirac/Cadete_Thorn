using UnityEngine;
using System.Collections;

namespace C_Thorn.InGame.IA
{
    public  class SC_BasicIA : MonoBehaviour
    {

        #region UnityCalls
        void Start() => StartCoroutine(CorrutineDie(8));

        private void Update() => ToForward();
        #endregion

        #region Custom public Methods
        protected IEnumerator CorrutineDie(int _time)
        {
            yield return new WaitForSeconds(_time);
            Destroy(this.gameObject);

        }
        protected void ToForward() => 
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (0.9f + 0.5f) * Time.deltaTime);
        #endregion
    }
}
