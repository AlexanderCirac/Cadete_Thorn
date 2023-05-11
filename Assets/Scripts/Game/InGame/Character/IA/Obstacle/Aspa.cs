using UnityEngine;

namespace C_Thorn.InGame.IA
{
    using C_Thorn.Tools.Templates;
    public class Aspa : BaseAI
    {
        #region Attributes
        [Header("Object rotating")]
        public GameObject _aspaObject;
        #endregion

        #region private custom method
        public override void ToActionBaseIA()
        {
            _aspaObject.transform.Rotate(Vector3.right * 30 * Time.deltaTime);
        }
        #endregion
    }
}
