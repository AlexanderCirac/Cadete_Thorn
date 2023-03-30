using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Game.Characters
{
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Tools.Enums;
    public class CharacterAnimation : MonoBehaviour
    {
        #region Attributes
        private Animator _animator => GetComponent<Animator>();
        private Enums_AnimationPlayer _currentState;
        public Enums_AnimationPlayer _animationPlay
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
                if ( value != _currentState )
                    ToolsAlex.SetNewAnimation(value , _animator);
            }
        }
        #endregion


    }
}
