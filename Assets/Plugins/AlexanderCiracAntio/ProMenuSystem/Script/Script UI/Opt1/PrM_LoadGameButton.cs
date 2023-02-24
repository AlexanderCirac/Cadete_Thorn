using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AlexanderCA.ProMenu.UI
{
    using AlexanderCA.ProMenu.Enum;
    public class PrM_LoadGameButton : PrM_Behaviour
    {
        /// <summary>
        /// this say what will button do on panels
        /// </summary>
        /// <param name="_loadEnum">Enmu to say the type of button </param>
        /// <param name="_panel"> the panel will be active or desactive </param>
        #region Custom Public Methods
        public void ToLoadClick(LoadGameEnum _loadEnum, GameObject _panel)
        {
            switch (_loadEnum)
            {
                 case LoadGameEnum.HiddenPanel:
                        this.gameObject.GetComponent<Button>().onClick.AddListener(() => _panel.SetActive(false));
                        return; 

                case LoadGameEnum.ShowPanel:
                        this.gameObject.GetComponent<Button>().onClick.AddListener(() => _panel.SetActive(true));
                        return; 
          
                case LoadGameEnum.None:
                default:
                        return;
            }
        }
        /// <summary>
        /// To load scene
        /// </summary>
        /// <param name="_iDLevel"> int to say the level scene </param>
        public void ToLoadClick(int _iDLevel = 0)
        {
            this.gameObject.GetComponent<Button>().onClick.AddListener( () =>
            {
                if(_loadBarManager._content._use._typeLoadBar == LoadBarEnmu.LoadedBar)
                {
                    _dataPersiten._idLoadLevel = _iDLevel;
                    SceneManager.LoadScene(_loadBarManager._content._use.m_nivel);
                }else
                SceneManager.LoadScene(_iDLevel);
            });
            return;
        }
        #endregion
    }
}
