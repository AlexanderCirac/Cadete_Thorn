using UnityEngine;

namespace C_Thorn.InGame.IA
{

    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Interfaces;
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Game.Characters;
    using C_Thorn.InGame.Controller;
    public class TrashIA : BaseAI, IEnterCollider
    {

        #region Attributes
        [Header("Points")]
        [SerializeField] int _point;
        #endregion

        #region private custom method
        public void ToEnterCollider(GameObject _player)
        {
            GameController.Instance._stateGame = Tools.Enums.Enums_StateGame.Deffet;
            if ( _player.GetComponent<PlayerController>() != null )
                _player.GetComponent<PlayerController>()._isDead = true;
            _ToDestroy();
        }

        public void IEnterBullet()
        {
            ToolsAlex.GetClampValue(FindObjectOfType<PlayerController>().countPoint , 1 , 100 , _point);
            _ToDestroy();
        }
        #endregion
    }
}
