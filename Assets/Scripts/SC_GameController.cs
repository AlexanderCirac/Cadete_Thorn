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
          void Awake() => Init();
          void Update () => OnSettings?.Invoke();
          #endregion

          #region Custom Private Methods
          void Init()
          {
             _instance = this;
             _datosJugador = !_datosJugador ? FindObjectOfType<SC_DatosJugador>() : null;
          }
          #endregion
    }
}
