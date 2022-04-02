using UnityEngine;

namespace C_Thorn.UI
{
    using C_Thorn.UI.Settings;
    using C_Thorn.InGame;
    public class MyUIMonoBehaviour : MonoBehaviour
    {
        protected SC_GameController _gameMenus => SC_GameController._instance;

        protected SC_SettingsUIController _settings => _gameMenus._settingsUI;
        protected SC_DatosJugador _datos => _gameMenus._datosJugador;
        protected SC_InGameUiController _inGameUI => _gameMenus._inGameUIController;
        protected SC_InGameManager _inGameManager => _gameMenus._InGameManager;
    }
}
