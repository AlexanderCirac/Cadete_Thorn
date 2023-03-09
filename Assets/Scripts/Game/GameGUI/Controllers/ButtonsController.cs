using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace C_Thorn.UI.Controller
{

using C_Thorn.Tools.Interfaces;
    public class ButtonsController : MonoBehaviour
    {
        #region Attributes
        [Header("Set alls buttons to acction")]
        [SerializeField] private Button[]  _buttons;
        #endregion

        #region UnityCalls
        private void Start()
        {
            if ( _buttons.Length == 0 ) return;
            for ( int _raidButtons = 0 ; _raidButtons < _buttons.Length ; _raidButtons++ )
            {
                if ( _buttons[_raidButtons].TryGetComponent(out IButtonAction _iActionButton) )
                {
                    _buttons[_raidButtons].onClick.AddListener(() => _iActionButton.ToButtonAction());
                }
            }
        }
        #endregion
    }
}
