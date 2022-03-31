using UnityEngine;

namespace C_Thorn.UI
{
    using C_Thorn.UI.Settings;
    public class SC_GameMenusController : MyUIMonoBehaviour
    {
        #region Attributs
        
        //Main tools
        public SC_SettingsUIController _settingsUIController;

        //singlenton
        public static SC_GameMenusController _instance;
        #endregion

        #region Unity Calls 
        public void Awake()
        {
            _instance = this;
        }
        #endregion
    }
}
