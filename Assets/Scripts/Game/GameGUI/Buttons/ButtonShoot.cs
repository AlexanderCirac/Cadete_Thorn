using UnityEngine;

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
        [SerializeField] GameObject _shootingPeephole;

        [Header("object Pool")]
        public  bool    _isUsePool = false;
        public  int     _maxCapacityPool = 100;
        private ToolsAlex.SingularPoolGeneric<Transform> _poolSystem;
        #endregion

        #region UnityCalls 
        void Start()
        {
            if ( _isUsePool )
            {
                _poolSystem = new ToolsAlex.SingularPoolGeneric<Transform>(_bulletPref.GetComponent<Transform>() , _maxCapacityPool);
            }
        }
        #endregion

        #region public custom methods 
        public void IToButtonAction()
        {
            if ( _isUsePool )
            {
                Transform bullet = _poolSystem.GetObject();
                bullet.transform.position = _shootingPeephole.transform.position;
                bullet.transform.rotation = _shootingPeephole.transform.rotation;
                bullet.gameObject.SetActive(true);
                bullet.GetComponent<IMonoPool>().poolMono = _poolSystem;
                bullet.GetComponent<ITypeDamage>()._typeBullet = TypeBullet.bulletPlayer;
                bullet.GetComponent<IMonoPool>().Init();
            }
        }
        #endregion
    }
}
