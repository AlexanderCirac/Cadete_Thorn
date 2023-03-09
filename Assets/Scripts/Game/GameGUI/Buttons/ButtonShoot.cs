using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace C_Thorn.UI
{
    using C_Thorn.Tools.Interfaces;
    public class ButtonShoot : MonoBehaviour, IButtonAction
    {
        #region Attributes
        [Header("Element Instantiate")]
        [SerializeField] BulletPref _bulletPref;
        [SerializeField] GameObject _puntero;

        [Header("object Pool")]
        public bool _isUsePool = false;
        public IObjectPool<BulletPref> pool;
        public bool _collectionCheck = false;
        public int _maxCapacity = 100;
        public int _defoultCapcity = 1000;
        #endregion

        #region UnityCalls 
        void Start()
        {
            if ( _isUsePool )
            {
                pool = new ObjectPool<BulletPref>(CreatePoolItem , OnTakeFromPool , OnReturnToPool , OnDestoiPoolObject , _collectionCheck , _defoultCapcity , _maxCapacity);
            }
        }
        #endregion

        #region private custom methods 
        private BulletPref CreatePoolItem()
        {
            return Instantiate(_bulletPref, _puntero.transform.position, _puntero.transform.rotation);
        }        
        private void OnReturnToPool(BulletPref _obj)
        {
            _obj.gameObject.SetActive(false);
        }            
        private void OnTakeFromPool(BulletPref _obj)
        {
            _obj.gameObject.SetActive(true);
        }        
        private void OnDestoiPoolObject(BulletPref _obj)
        {
            Destroy(_obj.gameObject);
        }
        private void Kill(BulletPref _obj)
        {
            if( _isUsePool )
            {
                pool.Release(_obj);
            }
        }
        #endregion

        #region public custom methods 

        #endregion
        public void ToButtonAction()
        {
            if ( _isUsePool )
            {
                var _bullet = pool.Get();
                _bullet.transform.position = _puntero.transform.position;
                _bullet.Init(Kill);
            }
        }
    }

}
