using UnityEngine;

namespace C_Thorn.InGame.IA
{
    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Interfaces;
    using AlexanderCA.Tools.Generics;
    public class RobotIA : BaseAI
    {
        #region Attributes
        [Header("Element Instantiate")]
        [SerializeField]    GameObject  _bulletPref;
        [SerializeField]    GameObject  _shootingPeephole;

        [Header("object Pool")]
        public  int _maxCapacityPool = 100;
        private ToolsAlex.SingularPoolGeneric<Transform> _singularPool;
        #endregion

        #region UnityCall
        private void OnBecameVisible()
        {
            DetectedPlayer();
            LookAtPlayer();
        }
        #endregion

        #region private custom method
        void DetectedPlayer()
        {
            if ( ToolsAlex.IsOverlap3D(LayerMask.NameToLayer("Player") , this.gameObject , ToolsAlex.TypeOverlap.sphere) )
            {
                ToActionBaseIA();
            }
        }
        void LookAtPlayer()
        {
            GameObject _player = GameObject.FindWithTag("Player");
            _shootingPeephole.transform.LookAt(_player.transform);
        }
        void ToShoot()
        {
            Transform bullet = _singularPool.GetObject();
            bullet.transform.position = _shootingPeephole.transform.position;
            bullet.transform.rotation = _shootingPeephole.transform.rotation;
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<IMonoPool>().poolMono = _singularPool;
            bullet.GetComponent<ITypeDamage>()._typeBullet = Tools.Enums.TypeBullet.bulletEnemy;
            bullet.GetComponent<IMonoPool>().Init();
        }
        #endregion

        #region public custom method
        public override void ToActionBaseIA()
        {
            InvokeRepeating(nameof(ToShoot) , 0.5f , 1f);
        }
        #endregion
    }
}
