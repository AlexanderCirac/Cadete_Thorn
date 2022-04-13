using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace C_Thorn.UI
{
    public class SC_UISpecialButtonToHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Attribute
        public  UnityEvent OnHold;
        [SerializeField] bool _isHolding;
        #endregion

        #region UnityCalls
        void Update() => OnHold?.Invoke();

        public void OnPointerDown(PointerEventData eventData) { _isHolding = true; }
        public void OnPointerUp(PointerEventData eventData) { _isHolding = false; }
        #endregion
    }

}
