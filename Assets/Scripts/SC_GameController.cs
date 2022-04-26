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
          [HideInInspector] public SC_SettingsUIController _settingsUI;
          [HideInInspector] public SC_DatosJugador _datosJugador;
          [HideInInspector] public SC_InGameUiController _inGameUIController;
          [HideInInspector] public SC_InGameManager _gameManager;
          [HideInInspector] public SC_InGameController _gameController;
          //events
          public event Action OnSettings;
          //singlenton
          [HideInInspector] public static SC_GameController _instance;
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
