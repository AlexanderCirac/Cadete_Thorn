using UnityEngine;

namespace C_Thorn.InGame.IA
{
    using C_Thorn.Tools.Templates;
    using C_Thorn.Tools.Interfaces;
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Game.Characters;
    using C_Thorn.InGame.Controller;
    public class RobotIA : BaseAI
    {
        #region Attributes
        [Header("Element Instantiate")]
        [SerializeField] GameObject _bulletPref;
        [SerializeField] GameObject _puntero;

        [Header("object Pool")]
        private ToolsAlex.PoolMonoObjectGeneric<Transform> pool;
        public int _maxCapacity = 100;
        #endregion

        #region UnityCall
        private void OnBecameVisible()
        {
            if ( ToolsAlex.IsOverlap3D(LayerMask.NameToLayer("Player"), this.gameObject , ToolsAlex.TypeOverlap.sphere) )
                ToAction();

            GameObject _player = GameObject.FindWithTag("Player");
            _puntero.transform.LookAt(_player.transform);

        }
        #endregion

        #region private custom method
        public void ToEnterCollider(GameObject _player)
        {
            GameController.Instance._stateGame = Tools.Enums.Enums_StateGame.Deffet;
            if ( _player.GetComponent<PlayerController>() != null )
                _player.GetComponent<PlayerController>()._isDead = true;
            _ToDestroy();
        }

        public void IEnterBullet()
        {         
            _ToDestroy();
        }

        public override void ToAction()
        {
            InvokeRepeating(nameof(ToShoot) , 0.5f , 1f);
        }

        void ToShoot()
        {
            Transform bullet = pool.GetObject();
            bullet.transform.position = _puntero.transform.position;
            bullet.transform.rotation = _puntero.transform.rotation;
            bullet.gameObject.SetActive(true); 
            bullet.GetComponent<IMonoPool>().poolMono = pool;
            bullet.GetComponent<ITypeDamage>()._typeBullet = Tools.Enums.TypeBullet.bulletEnemy;
            bullet.GetComponent<IMonoPool>().Init();
        }
        #endregion
    }
}
