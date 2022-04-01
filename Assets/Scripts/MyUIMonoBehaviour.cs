using UnityEngine;

namespace C_Thorn.UI
{
    using C_Thorn.UI.Settings;
    public class MyUIMonoBehaviour : MonoBehaviour
    {
        protected SC_GameController _gameMenus => SC_GameController._instance;

        protected SC_SettingsUIController _settings => _gameMenus._settingsUI;
        protected SC_DatosJugador _datos => _gameMenus._datosJugador;
    }
}
