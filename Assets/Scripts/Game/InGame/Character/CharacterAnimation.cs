using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Game.Characters
{
    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Enums;
    public class CharacterAnimation : MonoBehaviour
    {
        #region Attributes
        [SerializeField] private    InputTemplate   _inputs;
                         private    Animator        _animator;
        #endregion

        #region Unity Calls
        private void Awake()
        {
            TryGetComponent(out _animator);

        }
        private void Start()
        {
            _inputs._myDelegateAnimations += ToAnimatedStateMachine;
        }
        private void OnDestroy()
        {
            _inputs._myDelegateAnimations -= ToAnimatedStateMachine;
        }
        #endregion

        #region private custom Method       
        private void ToAnimatedStateMachine(Enums_AnimationPlayer _namePlay , bool _boolState)
        {
            if ( /*_animator.GetBool(_namePlay.ToString()) &&*/ _animator.GetBool(_namePlay.ToString()) == false )
            {
                _animator.SetBool(_namePlay.ToString() , _boolState);
                for ( int i = 0 ; i < _animator.parameterCount ; i++ )
                {
                    if ( _animator.GetParameter(i).name != _namePlay.ToString() )
                    {
                        _animator.SetBool(_animator.GetParameter(i).name , false);
                    }                    
                }               
            }

            ToRandomDead(_namePlay);
        }

        void ToRandomDead(Enums_AnimationPlayer _namePlay)
        {
            if( _namePlay  == Enums_AnimationPlayer.Dead )
            {
                _animator.SetInteger("Random_Dead" , Random.Range(0 , 3));
            }
        }
        #endregion
    }
}
