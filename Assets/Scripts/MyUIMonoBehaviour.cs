using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Thorn.UI
{
    using C_Thorn.UI.Settings;
    public class MyUIMonoBehaviour : MonoBehaviour
    {
        protected SC_GameMenusController _gameMenus => SC_GameMenusController._instance;

        protected SC_SettingsUIController _settings => _gameMenus._settings;
       
        
    }
}
