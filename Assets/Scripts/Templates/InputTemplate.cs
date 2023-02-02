using UnityEngine;


namespace C_Thorn.Game.Templates
{

    using C_Thorn.Tools.Enums;
    public abstract class InputTemplate : MonoBehaviour
    {
        #region Attributes
        public delegate void MyDelegateAnimations(Enums_AnimationPlayer _namePlay , bool _boolState);
        public MyDelegateAnimations _myDelegateAnimations;
        #endregion


        #region private custom method
        public abstract float GetHorizontal(bool _isTouchGraund);
        public abstract int GetJump(bool _isTouchGraund , bool _isDontLimit);
        public abstract bool GetFlip(SpriteRenderer _sprite);

        public virtual Enums_Inputs GetInputs()
        {

            Enums_Inputs _getInputs = Enums_Inputs.none;

            if ( Input.GetKey(KeyCode.Space) )
                _getInputs = Enums_Inputs.press;

            if ( Input.GetKeyDown(KeyCode.Space) )
                _getInputs = Enums_Inputs.down;

            if ( Input.GetKeyUp(KeyCode.Space) )
                _getInputs = Enums_Inputs.up;

            return _getInputs;
        }
        #endregion
    }
}