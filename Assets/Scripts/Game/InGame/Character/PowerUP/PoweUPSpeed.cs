using UnityEngine;

namespace C_Thorn.InGame.IA
{

    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Interfaces;
    using C_Thorn.InGame.Controller;
    public class PoweUPSpeed : BaseAI, IEnterCollider
    {
        #region private custom method
        public void ToEnterCollider(GameObject _player)
        {
            GameController.Instance._stateGame = Tools.Enums.Enums_StateGame.FastSpeed;
            _ToDestroy();
        }        
        #endregion
    }

}
