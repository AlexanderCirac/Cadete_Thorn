using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace C_Thorn.UI
{
    public class SC_MapaJuegoUiController : MyUIMonoBehaviour
    {
          #region Attributes
          [Header("Button")]
          [SerializeField] Button _quitButton;
          [System.Serializable] public class ButtonLevel {

            [SerializeField] string _name;
            public Button _levelButton;
            public int _iDLevel;
          }
          [Header("Button Level")]
          [SerializeField] ButtonLevel[] _arryLevelButton;
          #endregion

          #region UnityCalls
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
                  if (_count<= GetLevelDataPlayer)
                  {
                       _arryLevelButton[i-1]._levelButton.interactable = true;
                  }
              }

              _quitButton.onClick.AddListener(() => Application.Quit());
          }
          #endregion

          #region Methods
          private int GetLevelDataPlayer
          {
              get => _datos.m_nivel;
          }
          #endregion
    }
}


