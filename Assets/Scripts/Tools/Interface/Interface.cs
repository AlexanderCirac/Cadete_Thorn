using UnityEngine;

namespace C_Thorn.Tools.Interfaces
{
    using AlexanderCA.Tools.Generics;
    using C_Thorn.Tools.Enums;
    public interface IEnterCollider
    {
        void IToEnterCollider(GameObject _player);
    }
    public interface IEnterBullet
    {
        void ToEnterCollider();
    }
    public interface IChangeLife
    {
        public TypePlayer _TypePlayer { get; set; }
        void ToChangeLife(float _damage);
    } 
    public interface IButtonAction
    {
        void IToButtonAction();
    }
    public interface IMonoPool
    {
        public ToolsAlex.SingularPoolGeneric<Transform> poolMono { get; set; }
        public void Init();

    }
    public interface ITypeDamage
    {

        public TypeBullet _typeBullet { get; set; }

    }
    public interface IPluriPool
    {
        public ToolsAlex.PluralPoolGeneric<Transform> poolPluri { get; set; }
        public void Init();
    }
}