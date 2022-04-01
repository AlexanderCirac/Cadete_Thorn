using System;

namespace C_Thorn.UI
{
    using C_Thorn.UI.Settings;
    public class SC_GameController : MyUIMonoBehaviour
    {
          #region Attribute
          //Main tools UI
          public SC_SettingsUIController _settingsUI;
          public SC_DatosJugador _datosJugador;
          //events
          public event Action OnSettings;
          //singlenton
          public static SC_GameController _instance;
          #endregion

          #region Unity Call
          private void Awake()
          {
              _instance = this;
          }
          private void Update()
          {
                if(OnSettings != null)
                  OnSettings();
          }
          #endregion
    }
}
