using UnityEngine;

namespace C_Thorn.Game.Characters
{
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Tools.Enums;
    public class CharacterAnimation : MonoBehaviour
    {
        #region Attributes
        private     Animator                _animatorController  => GetComponent<Animator>();
        private     Enums_AnimationPlayer   _currentStateAnimation;
        public      Enums_AnimationPlayer   CurrentStateAnimation
        {
            get
            {
                return _currentStateAnimation;
            }
            set
            {
                if ( value != _currentStateAnimation )
                {
                    ToolsAlex.SetNewAnimation(value , _animatorController);
                    _currentStateAnimation = value;
                }
            }
        }
        #endregion
    }
}
