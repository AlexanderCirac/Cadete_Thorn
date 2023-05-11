using UnityEngine;

namespace C_Thorn.InGame.IA
{
    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Interfaces;
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Game.Characters;
    public class PowerUPPoint : BaseAI, IEnterCollider
    {
        #region Attributes
        [Header("Points")]
        [SerializeField] int _pointsReward;
        #endregion

        #region private custom method
        public void IToEnterCollider(GameObject _player)
        {
            ToolsAlex.GetClampValue(_player.GetComponent<PlayerController>()._countPoint , 1 , 100 , _pointsReward);
            _ToDestroy();
        }
        #endregion
    }
}