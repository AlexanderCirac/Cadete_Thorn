using UnityEngine;
using UnityEngine.UI;

namespace AlexanderCA.ProMenu.UI
{
  using AlexanderCA.ProMenu.Enum;
  public class PrM_PauseButton : MonoBehaviour
  {
    #region Custom Public Methods
    /// <summary>
    /// This function will be to give functionality to the button through
    /// </summary>
    /// <param name="_pauseEnum">Enmu to say the type of button</param>
    /// <param name="_panel">the panel will be active or desactive</param>
    public void ToPauseClick(GamePauseEnum _pauseEnum, GameObject _panel = null)
    {
      switch (_pauseEnum)
      {
        case GamePauseEnum.HiddenPanel:
          this.gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
              _panel.SetActive(false);
              Time.timeScale = 1;
            });
          return;

        case GamePauseEnum.ShowPanel:
          this.gameObject.GetComponent<Button>().onClick.AddListener(() =>
          {
            _panel.SetActive(true);
            Time.timeScale = 0;
          });
          return;

        case GamePauseEnum.None:
        default:
          return;
      }
    }
    #endregion
  }
}
