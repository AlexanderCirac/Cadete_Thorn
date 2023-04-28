using UnityEngine;

namespace C_Thorn.Tools.Templates
{
    using AlexanderCA.Tools.Generics;
    using C_Thorn.SO;
    using C_Thorn.Tools.Interfaces;
    using C_Thorn.Tools.Enums;
    public abstract class BaseAI : MonoBehaviour, IPluriPool, IChangeLife
    {
        #region Attributes
        public SOEnemy _soEnemy;
        private ToolsAlex.PoolMultiGeneric<Transform> pool;

        public ToolsAlex.PoolMultiGeneric<Transform> poolPluri { get => pool; set => pool = value; }
        private bool _cantDestroy;
        private float heal = 100;
        private float Heal { 
        
            get
            {
                return heal;
            }
            set
            {
                heal = value;
                if ( heal <= 0 && _cantDestroy )
                {
                    _ToDestroy();
                }
            }
        }
        private TypePlayer _typePlayer = TypePlayer.Enemy;
        public TypePlayer _TypePlayer { get => _typePlayer; set => _typePlayer = value; }
        #endregion
        #region private custom method       
        public virtual void ToAction() { }

        public virtual void Init()
        {
            Rigidbody _rg =GetComponent<Rigidbody>();
            _rg.velocity = transform.forward * _soEnemy._speed;
            Invoke(nameof(_ToDestroy) , 0.3f);
        }

        public virtual void _ToDestroy()
        {

            Transform[] inUseObjects = pool.GetInUseObjects();
            foreach ( Transform obj in inUseObjects )
            {
                pool.ReleaseObject(obj);
            }
        }

        public void ToChangeLife(float _damage)
        {
            Heal -= _damage;
        }
        #endregion
    }
}
