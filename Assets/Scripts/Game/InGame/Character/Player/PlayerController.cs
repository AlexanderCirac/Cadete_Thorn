using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Game.Characters
{
    using C_Thorn.Game.Templates;
    public class PlayerController : CharacterTemplate
    {

        #region 

        #endregion

        #region  UnityCalls
        private void OnMouseDrag()
        {
            ToMovementController();
        }
        #endregion

        #region  Abstarct


        protected override void ToAttackController()
        {
            throw new System.NotImplementedException();
        }

        protected override void ToMovementController()
        {
            Debug.Log("1");
            transform.position = _inputs.GetMove();
        }
        #endregion


    }
}
