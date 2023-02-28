using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.Tools.Interfaces
{
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
}