using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace C_Thorn.UI
{
    public class SC_UISpecialButtonToHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Attribute
        public  UnityEvent OnHold;
        [SerializeField] private bool _isHolding;

        #endregion

        #region UnityCalls
        void Update()
        {
          if (_isHolding)
          {
            OnHold.Invoke();
          }
        }
        #endregion

        #region Methods
        public void OnPointerDown(PointerEventData eventData)
        {
          _isHolding = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
          _isHolding = false;
        }
        #endregion
    }

}
