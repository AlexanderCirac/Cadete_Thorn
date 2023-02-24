using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace AlexanderCA.ProMenu.UI
{
  using AlexanderCA.ProMenu.Enum;
  public class PrM_PanelsButton : MonoBehaviour
  {
    #region Attributes
    CanvasRenderer[] _panels1;
    CanvasRenderer[] _panels2;
    #endregion

    #region Custom public Methods
    /// <summary>
    /// This function will be to give functionality to the button through
    /// </summary>
    /// <param name="_panelEnum">Enmu to say the type of button</param>
    public void ToPanelClick(PanelEnum _panelEnum)
    {
      switch (_panelEnum)
      {
        case PanelEnum.HiddenPanel:
          this.gameObject.GetComponent<Button>().onClick.AddListener(HiddenPanel);
          return;

        case PanelEnum.ShowPanel:
          this.gameObject.GetComponent<Button>().onClick.AddListener(ShowPanel);
          return;
      }
    }
    /// <summary>
    /// the panel will be active or desactive
    /// </summary>
    /// <param name="_panels1"></param>
    /// <param name="_panels2"></param>
    public void SetListPanel(CanvasRenderer[] _panels1 = null, CanvasRenderer[] _panels2 = null)
    {
      this._panels1 = _panels1;
      this._panels2 = _panels2;
    }
    #endregion

    #region Custom private Methods
    /// <summary>
    /// Show Panels 2 and desactive panels 1
    /// </summary>
    private void ShowPanel()
    {
      for (int i = 0; i < _panels1.Length; i++)
      {
        _panels1[i].gameObject.SetActive(false);
      }
      for (int i = 0; i < _panels2.Length; i++)
      {
        _panels2[i].gameObject.SetActive(true);
      }
    }
    /// <summary>
    /// Show panels 1 and desactive panels 2
    /// </summary>
    private void HiddenPanel()
    {
      for (int i = 0; i < _panels1.Length; i++)
        _panels1[i].gameObject.SetActive(true);
      for (int i = 0; i < _panels2.Length; i++)
        _panels2[i].gameObject.SetActive(false);
    }
    #endregion
  }
}
