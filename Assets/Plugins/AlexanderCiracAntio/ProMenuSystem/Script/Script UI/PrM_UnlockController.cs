using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexanderCA.ProMenu.UI;
public static class PrM_Unlock
{

    public static void UnLockID(int _iD)
    {
        PrM_UIManager._instanceUIManager._ListUnlockUI.Add(_iD);
    }
    public static void LockID(int _iD)
    {
        if ( PrM_UIManager._instanceUIManager._ListUnlockUI.Contains(_iD) )
        {
            PrM_UIManager._instanceUIManager._ListUnlockUI.Remove(_iD);
            PrM_UnlockController._instanceUnlock._OnUnlock?.Invoke(_iD , false);
        }
    }
}
namespace AlexanderCA.ProMenu.UI
{
    public class PrM_UnlockController : MonoBehaviour
    {

        #region Attributes
        public delegate void OnUnlock(int _id , bool _isUnlock);
        public OnUnlock _OnUnlock;
        public static PrM_UnlockController _instanceUnlock;
        #endregion


        #region UnityCalls     
        void Awake()
        {
            _instanceUnlock = this;
        }
        void OnDestroy()
        {

            PrM_UIManager._instanceUIManager._OnUnlock -= StateUnlock;
        }
        void Start()
        {
            Invoke(nameof(Initi) , 0.0001f);
            PrM_UIManager._instanceUIManager._OnUnlock += StateUnlock;
        }

        #endregion

        #region Costum private Methods
        void Initi()
        {
            PrM_UnlockElementUIInfo.ContentUnlockUI _opt8 = PrM_UIManager._instanceUIManager._contenido._Option8._content;
            for ( int i = 0 ; i < _opt8._unlockUIElements.Length ; i++ )
            {
                _OnUnlock?.Invoke(_opt8._unlockUIElements[i]._iDElement , false);
                Debug.Log(i);
            }
            if ( PrM_UIManager._instanceUIManager._listUnlockUI != null )
            {
                Invoke(nameof(StateUnlock) , 0.001f);

            }
        }
        void StateUnlock()
        {
            for ( int i = 0 ; i < PrM_UIManager._instanceUIManager._listUnlockUI.Count ; i++ )
            {
                _OnUnlock?.Invoke(PrM_UIManager._instanceUIManager._listUnlockUI[i] , true);
            }
        }
        void StateLock()
        {
            PrM_UnlockElementUIInfo.ContentUnlockUI _opt8 = PrM_UIManager._instanceUIManager._contenido._Option8._content;
            for ( int i = 0 ; i < _opt8._unlockUIElements.Length ; i++ )
            {
                _OnUnlock?.Invoke(_opt8._unlockUIElements[i]._iDElement , false);
            }

            Invoke(nameof(StateUnlock) , 0.001f);
        }

        #endregion

    }
}
