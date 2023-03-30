using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace C_Thorn.InGame.Mechanicals
{
    using AlexanderCA.Tools.Generics;
    public class RespawnMoving : MonoBehaviour
    {
        #region Attributes
        [Header("To Flip Flop velocity")]
        public  float _velocity = 5 ;
        internal  float initPosition;
        #endregion

        #region UnityCalls
        void Start() => Init();
        #endregion
        #region privat custom methods
        void Init()
        {
            Observable.EveryUpdate().Where(_ => GetBoolHorizontal()).Subscribe(_ => ToMovePingPong()); initPosition = this.transform.position.x;
        }

        void ToMovePingPong()
        {
            this.transform.position = new Vector3(initPosition +
                Mathf.PingPong(Time.time * Camera.main.orthographicSize / 2 , GetSizeScreen()) - GetSizeScreen() / 2 ,
                this.transform.position.y ,
                this.transform.position.z);
        }
        bool GetBoolHorizontal() { return ToolsAlex.GetObjectScreenLimits(Input.mousePosition , Camera.main , 2).isHorizontal; }
        float GetSizeScreen() { return ToolsAlex.GetObjectScreenLimits(this.transform.position , Camera.main , 3).rightLimit - ToolsAlex.GetObjectScreenLimits(this.transform.position , Camera.main , 3).leftLimit; }
        #endregion
    }
}
