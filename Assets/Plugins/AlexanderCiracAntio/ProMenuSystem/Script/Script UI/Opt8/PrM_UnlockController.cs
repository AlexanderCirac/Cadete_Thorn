using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexanderCA.ProMenu.UI;
using System.Linq;
public static class PrM_Unlock
{

    public static void UnLockID(int _iD)
    {
        if ( !PrM_UIManager._instanceUIManager._listUnlockUI.Contains(_iD) )
            PrM_UIManager._instanceUIManager.ListUnlockUI(_iD);
    }
    public static void LockID(int _iD)
    {
        PrM_UIManager._instanceUIManager.ListUnlockUI(_iD);
        PrM_UnlockController._instanceUnlock._OnUnlockController?.Invoke(_iD , false);
    }
    public static void NewLeastUnLockID(List<int> _iD)
    {
            PrM_UIManager._instanceUIManager._listUnlockUI = _iD;
            PrM_UIManager._instanceUIManager._OnListUnlock?.Invoke();      
    }
}
namespace AlexanderCA.ProMenu.UI
{
    public class PrM_UnlockController : MonoBehaviour
    {

        #region Attributes
        public delegate void OnUnlockController(int _id , bool _isUnlock);
        public OnUnlockController _OnUnlockController;
        public static PrM_UnlockController _instanceUnlock;
        #endregion


        #region UnityCalls     
        void Awake()
        {
            _instanceUnlock = this;
        }
        void OnDestroy()
        {

            PrM_UIManager._instanceUIManager._OnListUnlock -= StateUnlock;
        }
        void Start()
        {
            Invoke(nameof(Initi) , 0.0001f);
            PrM_UIManager._instanceUIManager._OnListUnlock += StateUnlock;
        }

        #endregion

        #region Costum private Methods
        void Initi()
        {
            PrM_UnlockElementUIInfo.ContentUnlockUI _opt8 = PrM_UIManager._instanceUIManager._contenido._Option8._content;
            for ( int i = 0 ; i < _opt8._unlockUIElements.Length ; i++ )
            {
                _OnUnlockController?.Invoke(_opt8._unlockUIElements[i]._iDElement , false);
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
                _OnUnlockController?.Invoke(PrM_UIManager._instanceUIManager._listUnlockUI[i] , true);
            }
        }
        void StateLock()
        {
            PrM_UnlockElementUIInfo.ContentUnlockUI _opt8 = PrM_UIManager._instanceUIManager._contenido._Option8._content;
            for ( int i = 0 ; i < _opt8._unlockUIElements.Length ; i++ )
            {
                _OnUnlockController?.Invoke(_opt8._unlockUIElements[i]._iDElement , false);
            }

            Invoke(nameof(StateUnlock) , 0.001f);
        }

        #endregion

    }
}
