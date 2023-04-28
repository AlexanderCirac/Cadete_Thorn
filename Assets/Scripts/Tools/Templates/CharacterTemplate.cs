using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Tools.Templates
{
    using C_Thorn.Tools.Interfaces;
    using C_Thorn.Tools.Enums;
    public abstract class CharacterTemplate : MonoBehaviour, IChangeLife
    {
        #region Attributes
        protected  InputTemplate  _inputs;
        private    float          _health = 100;
        protected  Vector3          _posInit;
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

        private TypePlayer _typePlayer = TypePlayer.Player;
        public TypePlayer _TypePlayer { get => _typePlayer; set => _typePlayer = value; }
        #endregion

        #region UnityCalls
        protected virtual void LateUpdate()
        {
            _posInit = transform.position;

        }
        protected virtual void Awake()
        {
            TryGetComponent(out _inputs);
            _posInit = transform.position;
        }
        #endregion

        #region abstart custom methods
        protected virtual void ToDeadController()
        {
            _inputs._myDelegateAnimations?.Invoke(Enums_AnimationPlayer.Dead , true);
        }
        public virtual void ToMovementController() {

            this.transform.position = _inputs.GetMove();
        }
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
