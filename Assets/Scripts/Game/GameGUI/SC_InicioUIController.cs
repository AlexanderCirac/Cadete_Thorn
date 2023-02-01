using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace C_Thorn.UI
{
    public class SC_InicioUIController : MyMonoBehaviour
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
          void Start() => StartUp();

          private void OnDestroy() => _gameMenus.OnSettings -= ToControlSettings;
          #endregion

          #region custom private Methods
          void StartUp()
          {
                //events
                _gameMenus.OnSettings += ToControlSettings;

                //buttons OnClick
                _textUIPanel.GetComponent<Button>().onClick.AddListener( () => SceneManager.LoadScene(1));

                //Initialize
                Invoke(nameof(ToShowTextUI), 0.5f);

          }
          void ToShowTextUI() =>_textUIPanel?.SetActive(true);
          void ToControlSettings()
          {
              _brightnessImage.color = new Color(_brightnessImage.color.r, _brightnessImage.color.g, _brightnessImage.color.b, _datos.m_Numero_Brillo - 0.1f);
              _musicAudioSource.volume = _datos.m_volumenMusica;
          }
          #endregion
    }

}
