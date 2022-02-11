using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.InGame
{
    public class SC_InGameManager : MonoBehaviour
    { 
        #region Attributes
        [HideInInspector] public bool _isStartGame = false;
        [HideInInspector] public bool _isWin = false;
        [HideInInspector] public bool _isLoset = false;
        [HideInInspector] public int _totalPoints = 0;
        public int _time = 1;
        public int _pointsMax = 0;
        public static float _velocityMove = 15;

        public static SC_InGameManager _instance;
        #endregion
        #region UnityCalls
        private void Awake()
        {
            _instance = this;
        }
        #endregion
  }
}
