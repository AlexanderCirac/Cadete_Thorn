using UnityEngine;

namespace C_Thorn.SO
{
    [CreateAssetMenu(fileName = "SO_Enemy" , menuName = "C_Thorn.SO/enemy" , order = 0)]
    public class SOEnemy : ScriptableObject
    {
        #region Attributes
        [Header("ID")]
        public string _nameID;

        [Header("Movement")]
        public float _speedMove;

        [Header("Attack")]
        public int _radDetection;
        public int _speedAttack;
        #endregion
    }
}
