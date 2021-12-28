using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.InGame
{
    public class SC_InGameManager : MonoBehaviour
    { 
        #region Attributes
        [HideInInspector] public bool _startToGame = false;
        [HideInInspector] public bool _winGame = false;
        [HideInInspector] public bool _endGame = false;
        [HideInInspector] public int _countPoints = 0;
        public int _countTime = 1;
        public int _countPointsMax = 0;
        #endregion

    }
}
