using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Pool;

namespace C_Thorn.UI
{
    using C_Thorn.Tools.Interfaces;
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Tools.Templates;
    public class ButtonShoot : MonoBehaviour, IButtonAction
    {
        #region Attributes
        [Header("Element Instantiate")]
        [SerializeField] GameObject _bulletPref;
        [SerializeField] GameObject _puntero;
        //[SerializeField] BulletPref _bulletPref;

        [Header("object Pool")]
        public bool _isUsePool = false;
        private ObjectPool<Transform> pool;
        public int _maxCapacity = 100;
        #endregion

        #region UnityCalls 
        void Start()
        {
            if ( _isUsePool )
            {
                pool = new ObjectPool<Transform>(_bulletPref.GetComponent<Transform>() , _maxCapacity);
             //   bulletPool.Init();

                // pool = new ObjectPool<BulletPref>(CreatePoolItem , OnTakeFromPool , OnReturnToPool , OnDestoiPoolObject , _collectionCheck , _defoultCapcity , _maxCapacity);
            }
        }
        #endregion

        #region private custom methods 
        //private BulletPref CreatePoolItem()
        //{
        //    return Instantiate(_bulletPref, _puntero.transform.position, _puntero.transform.rotation);
        //}        
        //private void OnReturnToPool(BulletPref _obj)
        //{
        //    _obj.gameObject.SetActive(false);
        //}            
        //private void OnTakeFromPool(BulletPref _obj)
        //{
        //    _obj.gameObject.SetActive(true);
        //}        
        //private void OnDestoiPoolObject(BulletPref _obj)
        //{
        //    Destroy(_obj.gameObject);
        //}
        //private void Kill(BulletPref _obj)
        //{
        //    if( _isUsePool )
        //    {
        //        pool.Release(_obj);
        //    }
        //}
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
                bullet.GetComponent<BulletPref>().Init(pool);
            }
        }
    }

}
