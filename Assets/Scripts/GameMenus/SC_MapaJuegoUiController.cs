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
          [SerializeField] private Button _quitButton;
          [System.Serializable] public class ButtonLevel {

            [SerializeField] private string _name;
            public Button _levelButton;
            public int _iDLevel;
          }
          [Header("Button Level")]
          [SerializeField] private ButtonLevel[] _arryLevelButton;
          private int _levelDataPlayer;
          
          //Main Tools
          public SC_SettingsUIController _settingsUIController;
          #endregion

          #region UnityCalls
          private void Awake()
          {
              _levelDataPlayer = _settingsUIController._dataPlayer.m_nivel;
          }
          void Start()
          {
              //Start game
              Time.timeScale = 1;

              //buttons 
              for (int i = 1; i <= _arryLevelButton.Length; i++)
              {
                  int _count = i;
                  //Add OnClick
                  _arryLevelButton[i-1]._levelButton.onClick.AddListener(() => SceneManager.LoadScene(_arryLevelButton[_count - 1]._iDLevel));
                  //show buttons
                  if (_count<= _levelDataPlayer)
                  {
                       _arryLevelButton[i-1]._levelButton.interactable = true;
                  }
              }

              _quitButton.onClick.AddListener(() => Application.Quit());
          }
          #endregion
    }
}
