using UnityEngine;

namespace AlexanderCA.ProMenu.UI
{
    public class PrM_QuitController : PrM_Behaviour
    {

        #region Attribute
        [SerializeField]string _joystick;
        [SerializeField]string _ownButton;
        [SerializeField]KeyCode _key;
        GameObject _panel;
        #endregion

        #region UnityCalls
        void Update() => ToActionKey();
        #endregion

        #region Custom public Methods
        public void SetPanel(GameObject _panel)
        {
            this._panel = _panel;
        }
        public void SetKey(string _joystick, KeyCode _key,string _ownButton)
        {
            this._joystick = _joystick;
            this._key = _key;
            this._ownButton = _ownButton;
        }
        #endregion

        #region Custom private Methods
        void ToActionKey()
        {
          if (_isCliced && !_uIManager._isQuitDesabled)
              if (_panel)
                _panel.SetActive(!_panel.activeSelf);
              else
              {
                Debug.Log("salir");
                    Application.Quit();
              }
        }
         bool _isCliced { get => (_joystick != "None" && _joystick != "" && Input.GetKeyDown(_joystick)) || (_key != KeyCode.None && Input.GetKeyDown(_key)) || (_ownButton != "" && Input.GetButtonDown(_ownButton)); }
        #endregion

    }
}
