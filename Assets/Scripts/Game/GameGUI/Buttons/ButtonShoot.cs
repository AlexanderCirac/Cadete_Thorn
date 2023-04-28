using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Pool;

namespace C_Thorn.UI
{
    using C_Thorn.Tools.Interfaces;
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Tools.Enums;
    public class ButtonShoot : MonoBehaviour, IButtonAction
    {
        #region Attributes
        [Header("Element Instantiate")]
        [SerializeField] GameObject _bulletPref;
        [SerializeField] GameObject _puntero;
        //[SerializeField] BulletPref _bulletPref;

        [Header("object Pool")]
        public bool _isUsePool = false;
        private ToolsAlex.PoolMonoObjectGeneric<Transform> pool;
        public int _maxCapacity = 100;
        #endregion

        #region UnityCalls 
        void Start()
        {
            if ( _isUsePool )
            {
                pool = new ToolsAlex.PoolMonoObjectGeneric<Transform>(_bulletPref.GetComponent<Transform>() , _maxCapacity);
            }
        }
        #endregion

        #region private custom methods 
       
        #endregion

        #region public custom methods 

        #endregion
        public void ToButtonAction()
        {
            if ( _isUsePool )
            {
                Transform bullet = pool.GetObject();
                bullet.transform.position = _puntero.transform.position;
                bullet.transform.rotation = _puntero.transform.rotation;
                bullet.gameObject.SetActive(true);
                bullet.GetComponent<IMonoPool>().poolMono = pool;
                bullet.GetComponent<ITypeDamage>()._typeBullet = TypeBullet.bulletPlayer;
                bullet.GetComponent<IMonoPool>().Init();
            }
        }
    }

}
