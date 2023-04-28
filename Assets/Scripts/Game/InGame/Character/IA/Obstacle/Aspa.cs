using UnityEngine;

namespace C_Thorn.InGame.IA
{

    using C_Thorn.Tools.Templates;
 
    public class Aspa : BaseAI
    {
        #region Attributes
        [Header("Object rotating")]
        public GameObject _aspa;
        #endregion

        #region UnityCall

        #endregion

        #region private custom method
        public override void ToAction()
        {
            _aspa.transform.Rotate ( Vector3.right * 30 * Time.deltaTime);
        }
        #endregion
    }
}
