using System;

namespace C_Thorn.UI
{
    using C_Thorn.UI.Settings;
    using C_Thorn.InGame;
    public class SC_GameController : MyMonoBehaviour
    {
          #region Attribute
          //Main tools UI
          public SC_SettingsUIController _settingsUI;
          public SC_DatosJugador _datosJugador;
          public SC_InGameUiController _inGameUIController;
          public SC_InGameManager _gameManager;
          public SC_InGameController _gameController;
          //events
          public event Action OnSettings;
          //singlenton
          public static SC_GameController _instance;
          #endregion

          #region Unity Call
          private void Awake()
          {
              _instance = this;
             _datosJugador = !_datosJugador ? FindObjectOfType<SC_DatosJugador>() : _datosJugador;
          }
          private void Update()
          {
                  OnSettings?.Invoke();
          }
          #endregion
    }
}
