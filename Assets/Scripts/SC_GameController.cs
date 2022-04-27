using System;
using UnityEngine;

namespace C_Thorn.UI
{
    using C_Thorn.UI.Settings;
    using C_Thorn.InGame;
    public class SC_GameController : MyMonoBehaviour
    {
          #region Attribute
          //Main tools UI
          internal SC_SettingsUIController _settingsUI;
          internal SC_DatosJugador _datosJugador;
          internal SC_InGameUiController _inGameUIController;
          internal SC_InGameManager _gameManager;
          internal SC_InGameController _gameController;
          //events
          internal event Action OnSettings;
          //singlenton
          internal static SC_GameController _instance;
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
             _settingsUI = !_settingsUI ? FindObjectOfType<SC_SettingsUIController>() : null;
             _inGameUIController = !_inGameUIController ? FindObjectOfType<SC_InGameUiController>() : null;
             _gameManager = !_gameManager ? FindObjectOfType<SC_InGameManager>() : null;
             _gameController = !_gameController ? FindObjectOfType<SC_InGameController>() : null;
          }
          #endregion
    }
}
