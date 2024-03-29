using UnityEngine;

namespace C_Thorn.Game.Characters
{
    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Enums;
    public class PlayerController : CharacterTemplate
    {

        #region 
        [Header("Variables controllers")]
        public  int     _countPoint;
        public  bool    _isDead;
        #endregion

        #region  UnityCalls
        private void OnMouseDrag()
        {
            if ( !_isDead )
            {
                ToMovementController();
            }
        }
        #endregion

        #region  Abstarct
        protected override void ToDeadController()
        {
            base.ToDeadController();
            Time.timeScale = 0;
        }
        protected override void ToAttackController()
        {
            throw new System.NotImplementedException();
        }
        public override void ToMovementController()
        {
            base.ToMovementController();
                //Controll animations
            if ( _inputs.GetMove().x > _posInit.x )
            {
                _inputs._myDelegateAnimations?.Invoke(Enums_AnimationPlayer.MoveLeft , true);
            }
            if ( _inputs.GetMove().x < _posInit.x )
            {
                _inputs._myDelegateAnimations?.Invoke(Enums_AnimationPlayer.MoveRigh , true);
            }
            if ( _inputs.GetMove().x == _posInit.x )
            {
                _inputs._myDelegateAnimations?.Invoke(Enums_AnimationPlayer.Idle , true);
            }
        }
         #endregion
    }
}

