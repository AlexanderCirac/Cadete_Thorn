using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace C_Thorn.UI
{
    public class SC_UISpecialButtonToHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Attribute
        public  UnityEvent OnHold;
        #endregion

        #region UnityCalls
        public void OnPointerDown(PointerEventData eventData) { IsHolding = true; }
        public void OnPointerUp(PointerEventData eventData) { IsHolding = false; }
        #endregion  
    
        #region custom private methods
        bool IsHolding{ set { if (value == true){ OnHold?.Invoke();}}}
        #endregion
    }
}
