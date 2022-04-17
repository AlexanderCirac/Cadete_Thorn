using UnityEngine;

namespace C_Thorn.InGame
{
    public class SC_InGameManager : MonoBehaviour
    { 
        #region Attributes
        [HideInInspector] public bool  _isStartGame =  false;
        [HideInInspector] public int   _totalPoints =  0;
        [HideInInspector] public ConditionVictoryEnum _conditionVictoryEnum = ConditionVictoryEnum.none;
        public int   _time = 1;
        public int   _pointsMax = 0;
        public float _velocityMove = 15;
        #endregion
    }
}
