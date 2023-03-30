using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.InGame.IA
{

    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Interfaces;
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Game.Characters;
    public class PoweUPSpeed : BaseAI, IEnterCollider
    {
        #region Attributes
        [SerializeField] int _point;
        #endregion

        #region private custom method
        public void ToEnterCollider(GameObject _player)
        {
        }

        #endregion
    }

}
