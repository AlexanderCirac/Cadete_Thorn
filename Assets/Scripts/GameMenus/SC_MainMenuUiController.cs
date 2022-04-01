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
          #endregion

          #region UnityCalls
          private void Start()
          {   
              //Start game
              Time.timeScale = 1;

              // Button OnClick
              _quitButton.onClick.AddListener(() => Application.Quit());
              _playButton.onClick.AddListener(() => SceneManager.LoadScene(2));
          }
          #endregion
    }
}
