using UnityEngine;

namespace C_Thorn.InGame.Controller
{
    using C_Thorn.Tools.Interfaces;
    using C_Thorn.Tools.Enums;
    public class Damage : MonoBehaviour, ITypeDamage
    {
        #region Attributes
        [Header("Damage")]
        public  int         damage      = -1000;
        [Space(2)]
        [Header("ID Bullet")]
        public  TypeBullet  TypeBullet  = TypeBullet.none;
        public  TypeBullet _typeBullet { get => TypeBullet; set => TypeBullet = value; }
        #endregion 

        #region UnityCalls
        void Start()
        {
            if ( TypeBullet == TypeBullet.none )
                TypeBullet = TypeBullet.bulletEnemy;
        }
        private void OnTriggerEnter(Collider other)
        {
            if ( other.TryGetComponent(out IChangeLife IChangeLife) )
            {
                bool isEnemy = _typeBullet == TypeBullet.bulletPlayer &&  IChangeLife._TypePlayer == TypePlayer.Enemy;
                bool isPlayer = _typeBullet == TypeBullet.bulletEnemy && IChangeLife._TypePlayer == TypePlayer.Player ;
                if ( isEnemy || isPlayer )
                    IChangeLife.ToChangeLife(damage);

            }
        }
        #endregion
    }
}
