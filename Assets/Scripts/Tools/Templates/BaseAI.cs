using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Tools.Templates
{
    using AlexanderCA.Tools.Generics;
    using C_Thorn.SO;
    using C_Thorn.Tools.Interfaces;
    public abstract class BaseAI : MonoBehaviour, IPluriPool
    {
        #region Attributes
        public SOEnemy _soEnemy;
        private ToolsAlex.PoolMultiGeneric<Transform> pool;

        public ToolsAlex.PoolMultiGeneric<Transform> poolPluri { get => pool; set => pool = value; }
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
        #endregion
    }
}
