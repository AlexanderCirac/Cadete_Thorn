using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using C_Thorn.UI.Settings;

namespace C_Thorn.UI
{
      public class SC_MapaJuegoUiController : MonoBehaviour
      {
          #region Attributes
          [Header("Button")]
          [SerializeField] private Button _quitGame;
          [System.Serializable] public class ButtonLevel {
            public string _name;
            public Button _buttonToLevel;
            public int _intLevel;
          }
          [Header("Button Level")]
          [SerializeField] private ButtonLevel[] _buttonLevel;
          [System.Serializable] public class ShowButtons {
            public string _name;
            public Button _buttonToShow;
          }
          [Header("Show buttons")]
          [SerializeField] private ShowButtons[] _showButtons;
           private int _levelDataPlayer;
          
          //Main Tools
          public SC_SettingsUIController _SettingsUIController;
          private 
          #endregion

          #region UnityCalls
          void Start()
          {
              Time.timeScale = 1;
               //Applying button onClick 
              int _raidLevel = 1, a = 0, b = 0, c= 0;
              for (; _raidLevel <= _buttonLevel.Length; _raidLevel++)
              {
                  int _count = _raidLevel;
                  _buttonLevel[_raidLevel-1]._buttonToLevel.onClick.AddListener(() => SceneManager.LoadScene(_buttonLevel[_count - 1]._intLevel));
              }
              _quitGame.onClick.AddListener(() => Application.Quit());
              //Invoke 
              Invoke(nameof(ShowButtonsDataPlayer),.2f);
          }
          #endregion

          #region Methods
          private void ShowButtonsDataPlayer()
          {
              //Activate Buttons Level
              _levelDataPlayer = _SettingsUIController._dataPlayer.m_nivel;
              int i = 1, a = 0, b = 0, c= 0;
              for ( ; i<= _levelDataPlayer; i++ )
              {
                  _showButtons[i-1]._buttonToShow.interactable = true;
              }
          }
          #endregion
      }

}
