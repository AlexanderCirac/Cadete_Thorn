using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlexanderCA.ProMenu.UI
{
    public class PrM_Unlock : MonoBehaviour
    {

        #region Attributes
        private PrM_UnlockController _unlockController;
        private int _idElement = 0;
        private Sprite _unlockSprite;
        private Sprite _lockSprite;

        #endregion

        #region UnityCalls
        void Start() => _unlockController._OnUnlock += ToStateUnlockUI;
        private void OnDestroy() => _unlockController._OnUnlock -= ToStateUnlockUI;
        #endregion

        #region Costum private Methods     

        void ToStateUnlockUI(int _id , bool _isUnlock)
        {
            if ( _id == _idElement )
            {
                Debug.Log(_isUnlock);
                GetComponent<Button>().interactable = _isUnlock;
                if ( _unlockSprite != null && _lockSprite != null )
                {
                    GetComponent<Image>().sprite = _isUnlock ? _unlockSprite : _lockSprite;
                }
            }
        }
        public void SetStateUnlock(PrM_UnlockController _unlockController , int _idElement, Sprite _unlockSprite, Sprite _lockSprite)
        {
            this._unlockController = _unlockController;
            this._idElement = _idElement;
            this._unlockSprite = _unlockSprite;
            this._lockSprite = _lockSprite;
        }
        #endregion

    }
}
