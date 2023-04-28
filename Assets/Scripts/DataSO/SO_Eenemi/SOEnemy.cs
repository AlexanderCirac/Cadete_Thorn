using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.SO
{
    [CreateAssetMenu(fileName ="SO_Enemy",  menuName = "C_Thorn.SO/enemy", order = 0)]
    public class SOEnemy : ScriptableObject
    {
        [Header("ID")]
        public string _name;
        [Header("Movement")]
        public float _speed;
        [Header("Attack")]
        public int _radDetection;
        public int _speedAttack;
    }
}
