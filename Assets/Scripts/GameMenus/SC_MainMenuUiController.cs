using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace C_Thorn.UI
{
    public class SC_MainMenuUiController : MonoBehaviour
    {
          #region Attributes
          [Header("Buttons")]
          [SerializeField]private Button _buttonQuit;
          [SerializeField]private Button _buttonPlay;
          #endregion

          #region UnityCalls
          private void Start()
          {   
              //Start game
              Time.timeScale = 1;

              // Button OnClick
              _buttonQuit.onClick.AddListener(() => Application.Quit());
              _buttonPlay.onClick.AddListener(() => SceneManager.LoadScene(2));
          }
          #endregion
    }
}
