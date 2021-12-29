using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace C_Thorn.UI
{
    public class SC_UISpecialButtonToHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Attribute
        public  UnityEvent OnHold;
        [SerializeField] private bool IsHolding;

        #endregion

        #region UnityCalls
        void Update()
        {
          if (IsHolding)
          {
            OnHold.Invoke();
          }
        }
        #endregion

        #region Methods
        public void OnPointerDown(PointerEventData eventData)
        {
          IsHolding = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
          IsHolding = false;
        }
        #endregion
    }

}
