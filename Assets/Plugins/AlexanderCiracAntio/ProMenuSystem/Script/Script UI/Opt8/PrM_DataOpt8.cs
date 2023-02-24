using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexanderCA.ProMenu.UI
{
    public class PrM_DataOpt8 : MonoBehaviour
    {
        #region      Attributes
        public List<int> _listUnlock;
        ////singlenton
        [HideInInspector] public static PrM_DataOpt8 _instance;
        #endregion
        #region UnityCalls
        private void Awake() => Init();

        void Start() => PrM_UIManager._instanceUIManager._OnListUnlock += UpdateData;


        #endregion

        #region custom private methods
        private void Init()
        {
            //Persistencia
            if ( _instance != null )
                Destroy(gameObject);
            else
            {
                _instance = this;
            }
            DontDestroyOnLoad(this.transform.gameObject);
        }

        private void UpdateData()
        {
            _listUnlock = PrM_UIManager._instanceUIManager._listUnlockUI;
        }
        #endregion
    }
}
