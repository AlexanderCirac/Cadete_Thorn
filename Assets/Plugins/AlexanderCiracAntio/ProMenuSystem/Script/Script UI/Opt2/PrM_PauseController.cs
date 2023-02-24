using UnityEngine;

namespace AlexanderCA.ProMenu.UI
{
    public class PrM_PauseController : PrM_Behaviour
    {
          #region Attribute
          string _joystick;
          string _ownButton;
          KeyCode _key;
          GameObject _panel;
          bool _isPauseGame = false;
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
          public void SetPauseGame(bool _isPauseGame) =>this._isPauseGame = _isPauseGame;
          #endregion

          #region Custom private Methods
          void ToActionKey()
          {
            if (_isCliced && !_uIManager._isPauseGameDesabled)
                if (_panel)
                {
                    //activate panel
                    _panel.SetActive(!_panel.activeSelf);
                    //stop time game
                    Time.timeScale = Time.timeScale != 0 && _isPauseGame ? 0 : 1;
                }
          }
           bool _isCliced { get => (_joystick != "None" && _joystick != "" && Input.GetKeyDown(_joystick)) || (_key != KeyCode.None && Input.GetKeyDown(_key)) || (_ownButton != "" && Input.GetButtonDown(_ownButton)); }
    #endregion
  }
}

