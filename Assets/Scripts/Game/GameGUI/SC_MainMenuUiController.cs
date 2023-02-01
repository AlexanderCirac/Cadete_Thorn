using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace C_Thorn.UI
{
    public class SC_MainMenuUiController : MonoBehaviour
    {
          #region Attributes
          [Header("Buttons")]
          [SerializeField] Button _quitButton;
          [SerializeField] Button _playButton;
        [System.Serializable] public class ButtonLevel {

            [SerializeField] string _name;
            public Button _uRLButton;
            public string _linkURL;
          }
          [Header("Button Level")]
          [SerializeField] ButtonLevel[] _arryURLButton;
          #endregion

          #region UnityCalls
          void Start() =>StartUp();
          #endregion

          #region Custom Private Methods
          void StartUp()
          {
              //Start game
              Time.timeScale = 1;

              // Button OnClick
              _quitButton.onClick.AddListener(() => Application.Quit());
              _playButton.onClick.AddListener(() => SceneManager.LoadScene(2));
              for (int i = 0; i < _arryURLButton.Length; i++)
                  _arryURLButton[i]._uRLButton.onClick.AddListener(() =>Application.OpenURL(_arryURLButton[i]._linkURL));
          }
          #endregion
    }
}
