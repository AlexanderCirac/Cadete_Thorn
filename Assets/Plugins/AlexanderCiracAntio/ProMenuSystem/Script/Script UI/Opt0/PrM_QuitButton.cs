using UnityEngine;
using UnityEngine.UI;

namespace AlexanderCA.ProMenu.UI
{
    using AlexanderCA.ProMenu.Enum;
    public class PrM_QuitButton : PrM_Behaviour
    {
        

        #region Custom Public Methods
        /// <summary>
        /// This function will be to give functionality to the button through
        /// </summary>
        /// <param name="_quitEnum">Enmu to say the type of button</param>
        /// <param name="_panel">the panel will be active or desactive</param>
        public void ToQuitClick(QuitEnum _quitEnum, GameObject _panel = null)
        {
            switch (_quitEnum)
            {
              case QuitEnum.Quit:
                this.gameObject.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
                return;

              case QuitEnum.HiddenPanel:
                this.gameObject.GetComponent<Button>().onClick.AddListener(() => _panel.SetActive(false));
                return;

              case QuitEnum.ShowPanel:
                this.gameObject.GetComponent<Button>().onClick.AddListener(() => _panel.SetActive(true));
                return;

              case QuitEnum.None:
              default:
                return;
            }
        }
        #endregion


    }
}
