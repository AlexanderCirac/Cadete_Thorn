using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Game.Templates
{
    using C_Thorn.Tools.Interfaces;
    using C_Thorn.Tools.Enums;
    public abstract class CharacterTemplate : MonoBehaviour, IChangeLife
    {
        #region Attributes
        protected  InputTemplate  _inputs;
        private    float          _health = 100;
        protected  float          _posInit;
        public float Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                if ( _health <= 0 )
                    ToDeadController();
            }
        }
        #endregion

        #region UnityCalls
        protected virtual void Awake()
        {
            TryGetComponent(out _inputs);
            _posInit = transform.position.y;
        }
        #endregion

        #region abstart custom methods
        protected virtual void ToDeadController()
        {

            _inputs._myDelegateAnimations(Enums_AnimationPlayer.Dead , true);
        }
        protected abstract void ToMovementController();
        protected abstract void ToAttackController();
        #endregion

        #region public custom methods
        public void ToChangeLife(float _damage)
        {
            Health -= _damage;
        }
        #endregion
    }
}
