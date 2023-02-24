using UnityEngine;

namespace AlexanderCA.ProMenu.UI
{

    public class PrM_MenuController : PrM_Behaviour
    {
        #region Attribute
        string _joystick;
        string _ownButton;
        KeyCode _key;
        CanvasRenderer[] _panel1;
        CanvasRenderer[] _panel2;
        #endregion

        #region UnityCalls
        void Update() => ToActionKey();
        #endregion

        #region Custom public Methods
        public void SetPanelsControllers(string _joystick, KeyCode _key, string _ownButton, CanvasRenderer[] _panel1, CanvasRenderer[] _panel2)
        {
          this._joystick = _joystick;
          this._key = _key;
          this._ownButton = _ownButton;
          this._panel1 = _panel1;
          this._panel2 = _panel2;
        }       
        public void SetPanelsKey(string _joystick, KeyCode _key, string _ownKey)
        {
          this._joystick = _joystick;
          this._key = _key;
          this._ownButton = _ownKey;
        }
        #endregion

        #region Custom private Methods
        void ToActionKey()
        {
          if (_isCliced && !_uIManager._isPanelDesabled)
          {
              for (int i = 0; i < _panel1.Length; i++)
              {
                _panel1[i].gameObject.SetActive(!_panel1[i].gameObject.activeSelf);
              }
              for (int i = 0; i < _panel2.Length; i++)
              {
                _panel2[i].gameObject.SetActive(!_panel2[i].gameObject.activeSelf);
              }
          }
          
        }
        bool _isCliced { get => (_joystick != "None" && _joystick != "" && Input.GetKeyDown(_joystick)) || (_key != KeyCode.None && Input.GetKeyDown(_key)) || (_ownButton != "" && Input.GetButtonDown(_ownButton)); }
        #endregion
    }
}
