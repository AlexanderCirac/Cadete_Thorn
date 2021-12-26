using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace C_Thorn
{
    public class SC_UIMantener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Attribute
        [SerializeField] private UnityEvent OnHold;
        [SerializeField] bool IsHolding;
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
