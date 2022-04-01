using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace C_Thorn.UI
{
    public class SC_InicioUIController : MyUIMonoBehaviour
    {
          #region Attributes
          [Header("Beggining UI")]
          [SerializeField] GameObject _textUIPanel;
          [SerializeField] Button _loadingButton ;
          [Header("Settings UI")]
          [SerializeField] Image _brightnessImage;
          [SerializeField] AudioSource _musicAudioSource;
          //Events
          #endregion

          #region UnityCalls
          void Start()
          {     
                //events
                _gameMenus.OnSettings += ToControlSettings;

                //Initialize
                Invoke(nameof(ToShowTextUI), 0.5f);

                //buttons OnClick
                _loadingButton.onClick.AddListener( () => SceneManager.LoadScene(1));
                
          }

          private void OnDestroy()
          {
                _gameMenus.OnSettings -= ToControlSettings;
          }
          #endregion

          #region Methods
          private  void ToShowTextUI()
          {
                _textUIPanel.SetActive(true);
          }
      
          private void ToControlSettings()
          {
              _brightnessImage.color = new Color(_brightnessImage.color.r, _brightnessImage.color.g, _brightnessImage.color.b, _datos.m_Numero_Brillo - 0.1f);
              _musicAudioSource.volume = _datos.m_volumenMusica;
          }
          #endregion
    }

}
