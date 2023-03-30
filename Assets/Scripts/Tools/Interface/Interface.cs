using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Tools.Interfaces
{
         using AlexanderCA.Tools.Generics;
    public interface IEnterCollider
    {
        void ToEnterCollider(GameObject _player);
    }

    public interface IChangeLife
    {
        void ToChangeLife(float _damage);
    }
    public interface IButtonAction
    {
        void ToButtonAction();
    }

    public interface IMonoPool
    {
        public ToolsAlex.PoolMonoObjectGeneric<Transform> poolMono { get; set; }
        public void Init();
        
    }
    public interface IPluriPool
    {
        public ToolsAlex.PoolMultiGeneric<Transform> poolPluri { get; set; }
        public void Init();
    }
}