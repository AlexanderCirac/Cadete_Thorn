using UnityEngine;
using UnityEngine.UI;

namespace C_Thorn.UI.Controller
{
    using C_Thorn.Tools.Interfaces;
    public class ButtonsController : MonoBehaviour
    {
        #region Attributes
        [Header("Set alls buttons to acction")]
        [SerializeField] private Button[]  _buttonArray;
        #endregion

        #region UnityCalls
        private void Start()
        {
            if ( _buttonArray.Length != 0 )
                ToAddActionButton();
        }
        #endregion

        #region private custom methods 
        void ToAddActionButton()
        {
            for ( int i = 0 ; i < _buttonArray.Length ; i++ )
            {
                if ( _buttonArray[i].TryGetComponent(out IButtonAction _iActionButton) )
                {
                    _buttonArray[i].onClick.AddListener(() => _iActionButton.IToButtonAction());
                }
            }
        }
        #endregion
    }
}
